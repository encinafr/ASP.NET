using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CursoASP.NETMVC.Models
{
    public class ApplicationDbContex : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Dirección> Direccion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("DateTime"));
            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Codigo"))
                .Configure(p => p.IsKey());
            modelBuilder.Entity<Dirección>().HasRequired(x => x.Persona);
            base.OnModelCreating(modelBuilder);
        }
    }
}