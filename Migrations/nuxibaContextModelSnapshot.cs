﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nuxibaService.Contexto;

#nullable disable

namespace nuxibaService.Migrations
{
    [DbContext(typeof(NuxibaContext))]
    partial class nuxibaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("nuxibaService.Model.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginId"));

                    b.Property<int>("Extencion")
                        .HasColumnType("int");

                    b.Property<int>("TipoMov")
                        .HasColumnType("int");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("LoginId");

                    b.ToTable("login");
                });

            modelBuilder.Entity("nuxibaService.Model.ccloglogin", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogId"));

                    b.Property<decimal>("Extencion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoMov")
                        .HasColumnType("int");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("LogId");

                    b.ToTable("ccloglogin");
                });
#pragma warning restore 612, 618
        }
    }
}
