using Patron.WebWriter.Data.Attributes;
using Patron.WebWriter.Data.Entity;
using Patron.WebWriter.General.Expansions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patron.WebWriter.Data.Generic;

namespace Patron.WebWriter.EF
{
    public partial class ServiceDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
