﻿// <auto-generated />
using System;
using Cargo.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cargo.Repository.Migrations
{
    [DbContext(typeof(CargoDbContext))]
    [Migration("20250213132005_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cargo.Repository.Entities.Carrier", b =>
                {
                    b.Property<int>("CarrierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrierId"));

                    b.Property<bool>("CarrierIsActive")
                        .HasColumnType("bit");

                    b.Property<string>("CarrierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarrierPlusDesiCost")
                        .HasColumnType("int");

                    b.HasKey("CarrierId");

                    b.ToTable("Carrier");
                });

            modelBuilder.Entity("Cargo.Repository.Entities.CarriersConfiguration", b =>
                {
                    b.Property<int>("CarrierConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrierConfigurationId"));

                    b.Property<decimal>("CarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMaxDesi")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMinDesi")
                        .HasColumnType("int");

                    b.HasKey("CarrierConfigurationId");

                    b.HasIndex("CarrierId");

                    b.ToTable("CarriersConfiguration");
                });

            modelBuilder.Entity("Cargo.Repository.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderCarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderDesi")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CarrierId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Cargo.Repository.Entities.CarriersConfiguration", b =>
                {
                    b.HasOne("Cargo.Repository.Entities.Carrier", "Carrier")
                        .WithMany("CarriersConfigurations")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("Cargo.Repository.Entities.Order", b =>
                {
                    b.HasOne("Cargo.Repository.Entities.Carrier", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("Cargo.Repository.Entities.Carrier", b =>
                {
                    b.Navigation("CarriersConfigurations");
                });
#pragma warning restore 612, 618
        }
    }
}
