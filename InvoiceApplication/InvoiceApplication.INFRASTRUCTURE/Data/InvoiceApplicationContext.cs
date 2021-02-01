using InvoiceApplication.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApplication.INFRASTRUCTURE.Data
{
    public class InvoiceApplicationContext : DbContext
    {
        public InvoiceApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Factura> Facturi { get; set; }
        public DbSet<DetaliiFactura> DetaliiFacturi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>().HasKey(f => new { f.IdFactura, f.IdLocatie });
            modelBuilder.Entity<Factura>(f =>
            {
                f.HasKey(x => x.IdFactura);
                f.Property(x => x.IdFactura).ValueGeneratedOnAdd();
            });
        }
    }
}
