﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace turism
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class turismEntities : DbContext
    {
        public turismEntities()
            : base("name=turismEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Marshrut> Marshrut_ET { get; set; }
        public virtual DbSet<Otel> Otel_ET { get; set; }
        public virtual DbSet<Putevka> Putevka_ET { get; set; }
        public virtual DbSet<Turist> Turist_ET { get; set; }
        public virtual DbSet<Usluga> Usluga_ET { get; set; }
    }
}
