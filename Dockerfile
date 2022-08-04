#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runner
WORKDIR /app
EXPOSE 80

RUN apt update && \
    apt install -y curl


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Patron.WebWriter/Patron.WebWriter.API/Patron.WebWriter.API.csproj", "Patron.WebWriter/Patron.WebWriter.API/"]
COPY ["Patron.WebWriter/Patron.WebWriter.BI/Patron.WebWriter.BI.csproj", "Patron.WebWriter/Patron.WebWriter.BI/"]
COPY ["Patron.WebWriter/Patron.WebWriter.General/Patron.WebWriter.General.csproj", "Patron.WebWriter/Patron.WebWriter.General/"]
COPY ["Patron.WebWriter/Patron.WebWriter.Data/Patron.WebWriter.Data.csproj", "Patron.WebWriter/Patron.WebWriter.Data/"]
RUN dotnet restore "Patron.WebWriter/Patron.WebWriter.API/Patron.WebWriter.API.csproj"
COPY . .
WORKDIR "/src/Patron.WebWriter/Patron.WebWriter.API"
RUN dotnet build "Patron.WebWriter.API.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "Patron.WebWriter.API.csproj" -c Release -o /app/publish


FROM runner AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Patron.WebWriter.API.dll"]