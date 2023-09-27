﻿// <auto-generated />
using CRM.Users._DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CRM.Users.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CRM.Users.Models.RegisterUser", b =>
                {
                    b.Property<long>("regesterid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("regesterid"));

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("lattitude")
                        .HasColumnType("text");

                    b.Property<string>("longtitude")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phonenumber")
                        .HasColumnType("text");

                    b.HasKey("regesterid");

                    b.HasIndex("email", "phonenumber")
                        .IsUnique();

                    b.ToTable("RegisterUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
