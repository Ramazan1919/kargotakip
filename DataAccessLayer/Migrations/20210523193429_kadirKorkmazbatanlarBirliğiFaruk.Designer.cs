﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(StdContext))]
    [Migration("20210523193429_kadirKorkmazbatanlarBirliğiFaruk")]
    partial class kadirKorkmazbatanlarBirliğiFaruk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataEntity.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DepartureDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ReceiverAddress");

                    b.Property<int>("Remaining");

                    b.Property<string>("SenderAddress");

                    b.Property<string>("ShippingNote");

                    b.Property<int>("ShippmentPackageId");

                    b.Property<string>("Title");

                    b.Property<string>("TrackingId");

                    b.HasKey("Id");

                    b.HasIndex("ShippmentPackageId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("DataEntity.ShippmentPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("RemainigDistance");

                    b.Property<int>("Size");

                    b.Property<double>("TotalDistance");

                    b.Property<int>("Weight");

                    b.HasKey("Id");

                    b.ToTable("ShippmentPackages");
                });

            modelBuilder.Entity("DataEntity.WeightAndSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price");

                    b.Property<int>("Size");

                    b.Property<int>("WeightMax");

                    b.Property<int>("WeightMin");

                    b.HasKey("Id");

                    b.ToTable("WeightAndSizes");
                });

            modelBuilder.Entity("DataEntity.Shipment", b =>
                {
                    b.HasOne("DataEntity.ShippmentPackage", "ShippmentPackage")
                        .WithMany()
                        .HasForeignKey("ShippmentPackageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
