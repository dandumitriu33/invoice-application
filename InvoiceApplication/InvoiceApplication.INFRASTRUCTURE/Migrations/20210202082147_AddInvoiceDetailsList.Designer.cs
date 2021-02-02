﻿// <auto-generated />
using System;
using InvoiceApplication.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvoiceApplication.INFRASTRUCTURE.Migrations
{
    [DbContext(typeof(InvoiceApplicationContext))]
    [Migration("20210202082147_AddInvoiceDetailsList")]
    partial class AddInvoiceDetailsList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvoiceApplication.CORE.Entities.DetaliiFactura", b =>
                {
                    b.Property<int>("IdDetaliiFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cantitate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("FacturaIdFactura")
                        .HasColumnType("int");

                    b.Property<int>("IdFactura")
                        .HasColumnType("int");

                    b.Property<int>("IdLocatie")
                        .HasColumnType("int");

                    b.Property<string>("NumeProdus")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("PretUnitar")
                        .HasColumnType("money");

                    b.Property<decimal>("Valoare")
                        .HasColumnType("money");

                    b.HasKey("IdDetaliiFactura");

                    b.HasIndex("FacturaIdFactura");

                    b.ToTable("DetaliiFacturi");
                });

            modelBuilder.Entity("InvoiceApplication.CORE.Entities.Factura", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFactura")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLocatie")
                        .HasColumnType("int");

                    b.Property<string>("NumarFactura")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NumeClient")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("IdFactura");

                    b.ToTable("Facturi");
                });

            modelBuilder.Entity("InvoiceApplication.CORE.Entities.DetaliiFactura", b =>
                {
                    b.HasOne("InvoiceApplication.CORE.Entities.Factura", null)
                        .WithMany("Detalii")
                        .HasForeignKey("FacturaIdFactura");
                });
#pragma warning restore 612, 618
        }
    }
}
