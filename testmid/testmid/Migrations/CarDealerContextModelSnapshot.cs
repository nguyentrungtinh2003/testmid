﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testmid.Models.Data;

#nullable disable

namespace testmid.Migrations
{
    [DbContext(typeof(CarDealerContext))]
    partial class CarDealerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PartCar", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "PartId")
                        .HasName("PK_CarPart");

                    b.HasIndex(new[] { "PartId" }, "IX_CarPart_PartsId");

                    b.ToTable("PartCars", (string)null);
                });

            modelBuilder.Entity("testmid.Models.Data.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TravelledDistance")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("testmid.Models.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsYoungDriver")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("testmid.Models.Data.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "SupplierId" }, "IX_Parts_SupplierId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("testmid.Models.Data.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CarId" }, "IX_Sales_CarId");

                    b.HasIndex(new[] { "CustomerId" }, "IX_Sales_CustomerId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("testmid.Models.Data.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsImporter")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("PartCar", b =>
                {
                    b.HasOne("testmid.Models.Data.Car", null)
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CarPart_Cars_CarsId");

                    b.HasOne("testmid.Models.Data.Part", null)
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CarPart_Parts_PartsId");
                });

            modelBuilder.Entity("testmid.Models.Data.Part", b =>
                {
                    b.HasOne("testmid.Models.Data.Supplier", "Supplier")
                        .WithMany("Parts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("testmid.Models.Data.Sale", b =>
                {
                    b.HasOne("testmid.Models.Data.Car", "Car")
                        .WithMany("Sales")
                        .HasForeignKey("CarId");

                    b.HasOne("testmid.Models.Data.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("testmid.Models.Data.Car", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("testmid.Models.Data.Customer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("testmid.Models.Data.Supplier", b =>
                {
                    b.Navigation("Parts");
                });
#pragma warning restore 612, 618
        }
    }
}
