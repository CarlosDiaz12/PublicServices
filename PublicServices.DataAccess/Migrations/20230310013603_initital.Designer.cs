﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublicServices.DataAccess.Data;

#nullable disable

namespace PublicServices.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230310013603_initital")]
    partial class initital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PublicServices.Core.Entities.HistorialCrediticio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConceptoDeuda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MontoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RNC_Acreedor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HistorialCrediticio");
                });

            modelBuilder.Entity("PublicServices.Core.Entities.IndiceInflacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Indice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Periodo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("IndiceInflacion");
                });

            modelBuilder.Entity("PublicServices.Core.Entities.Moneda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abreviatura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Moneda");
                });

            modelBuilder.Entity("PublicServices.Core.Entities.TasaCambiaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("MonedaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MonedaId");

                    b.ToTable("TasaCambiaria");
                });

            modelBuilder.Entity("PublicServices.Core.Entities.TasaCambiaria", b =>
                {
                    b.HasOne("PublicServices.Core.Entities.Moneda", "Moneda")
                        .WithMany()
                        .HasForeignKey("MonedaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Moneda");
                });
#pragma warning restore 612, 618
        }
    }
}