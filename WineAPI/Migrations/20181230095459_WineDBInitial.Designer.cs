﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WineAPI.Models;

namespace WineAPI.Migrations
{
    [DbContext(typeof(WineServiceContext))]
    [Migration("20181230095459_WineDBInitial")]
    partial class WineDBInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WineAPI.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Region")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Producer");

                    b.HasData(
                        new { Id = 1, Country = "France", Name = "Union de producteurs de Saint-Emilion", Region = "Saint-Emilion" },
                        new { Id = 2, Country = "France", Name = "André Lurton", Region = "Bordeaux" }
                    );
                });

            modelBuilder.Entity("WineAPI.Models.Wine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("DrinkBefore");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProducerId");

                    b.Property<DateTime>("PurchasedOn");

                    b.Property<int?>("TypeId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.HasIndex("TypeId");

                    b.ToTable("Wine");

                    b.HasData(
                        new { Id = 1, Amount = 1, DrinkBefore = 2018, Name = "Tour de Bonnet", Price = 0m, PurchasedOn = new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), Year = 2013 },
                        new { Id = 2, Amount = 5, DrinkBefore = 2016, Name = "Saint-Emilion Grand Cru", Price = 13.99m, PurchasedOn = new DateTime(2012, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), Year = 2010 },
                        new { Id = 3, Amount = 1, DrinkBefore = 0, Name = "Tour de Bonnet", Price = 13.99m, PurchasedOn = new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), Year = 2013 }
                    );
                });

            modelBuilder.Entity("WineAPI.Models.WineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Type");

                    b.HasData(
                        new { Id = 1, Description = "Red wines", Type = "Red" },
                        new { Id = 2, Description = "White wines", Type = "White" },
                        new { Id = 3, Description = "Wines best suited for dessert", Type = "Dessert" }
                    );
                });

            modelBuilder.Entity("WineAPI.Models.Wine", b =>
                {
                    b.HasOne("WineAPI.Models.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerId");

                    b.HasOne("WineAPI.Models.WineType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
