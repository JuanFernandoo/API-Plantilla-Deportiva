﻿// <auto-generated />
using System;
using FcBarcelona.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FcBarcelona.Migrations
{
    [DbContext(typeof(TeamContext))]
    partial class TeamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Auditoria", b =>
                {
                    b.Property<int>("IdCambio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCambio"));

                    b.Property<string>("Accion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DatosAnteriores")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DatosNuevos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("PC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tabla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCambio");

                    b.ToTable("Auditorias");
                });

            modelBuilder.Entity("FcBarcelona.Models.Barcelona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Posicion")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasFilter("[Nombre] IS NOT NULL");

                    b.ToTable("Plantilla");
                });
#pragma warning restore 612, 618
        }
    }
}
