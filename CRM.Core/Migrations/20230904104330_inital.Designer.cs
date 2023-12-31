﻿// <auto-generated />
using CRM.Core._DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CRM.Core.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20230904104330_inital")]
    partial class inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CRM.Core.Models.Device", b =>
                {
                    b.Property<long>("deviceid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("deviceid"));

                    b.Property<string>("devicename")
                        .HasColumnType("text");

                    b.HasKey("deviceid");

                    b.HasIndex("devicename")
                        .IsUnique();

                    b.ToTable("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
