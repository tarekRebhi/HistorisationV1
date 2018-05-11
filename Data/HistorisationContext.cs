using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entitee;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.CustumConvention;

namespace Data
{
    public class HistorisationContext:DbContext
    {
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Histo> Historisations { get; set; }
        public DbSet<Pause> Pauses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add<DateTime2Convention>();
        }
    }
}
