﻿// <auto-generated />
using FrontDeskApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FrontDeskApp.Data.Migrations
{
    [DbContext(typeof(FrontDeskAppDbContext))]
    [Migration("20220109194319_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FrontDeskApp.Core.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CustomerPhoneNumer")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("FrontDeskApp.Core.Models.Facility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("FacilityId");

                    b.ToTable("Facility");

                    b.HasData(
                        new
                        {
                            FacilityId = 1,
                            FacilityName = "Facility 1"
                        },
                        new
                        {
                            FacilityId = 2,
                            FacilityName = "Facility 2"
                        },
                        new
                        {
                            FacilityId = 3,
                            FacilityName = "Facility 3"
                        });
                });

            modelBuilder.Entity("FrontDeskApp.Core.Models.Storage", b =>
                {
                    b.Property<int>("StorageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("StorageFacilityId")
                        .HasColumnType("int");

                    b.Property<int>("StorageStatus")
                        .HasColumnType("int");

                    b.HasKey("StorageId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StorageFacilityId");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("FrontDeskApp.Core.Models.StorageFacility", b =>
                {
                    b.Property<int>("StorageFacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<int>("SlotCount")
                        .HasColumnType("int");

                    b.Property<string>("StorageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("StorageFacilityId");

                    b.HasIndex("FacilityId");

                    b.ToTable("StorageFacility");
                });

            modelBuilder.Entity("FrontDeskApp.Core.Models.Storage", b =>
                {
                    b.HasOne("FrontDeskApp.Core.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrontDeskApp.Core.Models.StorageFacility", "StorageFacility")
                        .WithMany()
                        .HasForeignKey("StorageFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrontDeskApp.Core.Models.StorageFacility", b =>
                {
                    b.HasOne("FrontDeskApp.Core.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}