﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnessClient
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FitnessAppEntities : DbContext
    {
        public FitnessAppEntities()
            : base("name=FitnessAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<Programm> Programm { get; set; }
        public DbSet<Thema> Thema { get; set; }
        public DbSet<Trainingsart> Trainingsart { get; set; }
        public DbSet<Uebung> Uebung { get; set; }
        public DbSet<Verzeichnis> Verzeichnis { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Training> Training { get; set; }
    }
}
