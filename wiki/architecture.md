# Информация об архитектуре приложения и подключенных библиотек

Для полноценной работы сервиса используются некоторые сторонние модули.
1) AutoMapper -> позволяет подключать внутри себя автоматическое переключение моделей. Подробнее https://automapper.org/
2) AutoFac -> замена привычного DI от Microsoft для более удобной настройки. Подробнее https://autofac.readthedocs.io/en/latest/
3) Swagger -> автоматически генерируемый веб-интерфейс для тестирования. Подробнее https://starkovden.github.io/swagger-ui-tutorial.html

Весь сервис разделён на внутренних 4 проекта для более удобного и понятного распределения классов программы:

+ Patron.WebWriter.API
+ Patron.WebWriter.BI
+ Patron.WebWriter.Data
+ Patron.WebWriter.General

## Patron.WebWriter.API
API является главенствующим проектом. Это приложение, остальное -> подключаемые модели.
Внутри архитектуры API содержатся разделы:
### Properties
Системная директория для настроек приложения. Из интересного, в папке
### Authentication
Директория, предназначенная для хранения схем аутентификации и принадлежащих им классов.
### Configurations
Содержит внутри себя настройки для AutoMapper и AutoFac.
Внутри директории AutoMapper имеется раздел Expansions. Позволяет подключать более сложные решения для автоматическогого маппинга моделей. Подробнее -> https://docs.automapper.org/en/stable/Custom-value-resolvers.html
## Patron.WebWriter.BI
BI является сервисом для бизнес-логики приложения. Отвечает за интеграции, взаимодействие с БД и в сумме, бОльшая часть логики расположена именно внутри BI проекта.
Внутри себя имеет следующую иерархию директорий:
### EF
Внутри себя содержит файлы ModelCreating и ServiceDbContext, отвечающие за настройку подключения к базе данных с помощью EntityFramework.
ModelCreating отвечает за первичное заполнение моделей, ServiceDbContext за преднастройки подключения и взаимодействия с таблицами.
### Options
Внутри себя содержит файлы настроек. Config.cs является главнейшим. При добавлении новых полей настроек, не забывайте добавить модель в них.
### Interfaces
Содержит интерфейсы для сервисов.
### Services
Содержит сами сервисы. Сервисы наследуются от Base<TEndity, TDto>
## Patron.WebWriter.Data
Проект отвечает за все модели, базовые модели и статические данные. А так же, аттрибуты.
### Attributes
Содержит внутри себя кастомные атрибуты.
### Base
Содержит внутри себя базовые модели, переиспользуемые в других моделях.
### Dto
Содержит внутри себя любые модели с передающими или меняющимися данными, в процессе исполнения бизнес-логики.
### Entity
Содержит внутри себя энтити по табличкам для EntityFramework. Наследуются от Base и Base2.
### Enums
Содержит различные списики. Например, список кодов состояния ответа от Return моделей.
### Filters
Содердит модели для фильтров (для GET-запросов по получению списков элементов)
### Generic
Содержит статические данные. Например, константы.
### Return
Содержит возвратные модели. Наследуются от BaseReturn
### ViewModels
Содержит два раздела: Input и Output.
Input в свою очередь содержит так же Create и Edit разделы, предназначенные для создания или изменения данных внутри сервиса.
В данный момент, Output модели не используются, вместо них, для удобства, возвращются DTO
## Patron.WebWriter.General
Проект содержащий внутри дополнительные бизнес логики.
### Exceptions
Содержит внутри себя кастомные исключения
### Expansions
Внутри себя содержат расширения для LINQ. Преобразования, фиксы и различные дополнения.
