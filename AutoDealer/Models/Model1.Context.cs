﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoDealer.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AutoDealerEntities : DbContext
    {
        public AutoDealerEntities()
            : base("name=AutoDealerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Automoviles> Automoviles { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<FacturasDetalles> FacturasDetalles { get; set; }
        public DbSet<Gastos> Gastos { get; set; }
        public DbSet<Liquidaciones> Liquidaciones { get; set; }
        public DbSet<Liquidaciones_Detalles> Liquidaciones_Detalles { get; set; }
        public DbSet<Showrooms> Showrooms { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TiposDeGastos> TiposDeGastos { get; set; }
        public DbSet<Fabricantes> Fabricantes { get; set; }
        public DbSet<Modelos> Modelos { get; set; }
        public DbSet<TiposAutomoviles> TiposAutomoviles { get; set; }
        public DbSet<Trim> Trim { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<PersonasRoles> PersonasRoles { get; set; }
        public DbSet<TiposRoles> TiposRoles { get; set; }
    }
}
