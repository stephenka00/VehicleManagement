﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerLibrary.Data;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240415152408_TokenInfo")]
    partial class TokenInfo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaseLibrary.Entities.Admin", b =>
                {
                    b.Property<int?>("admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("admin_id"));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("admin_id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("BaseLibrary.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("applicationUsers");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Car", b =>
                {
                    b.Property<int?>("car_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("car_id"));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("car_id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Customer", b =>
                {
                    b.Property<int?>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("customer_id"));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customer_id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Employee", b =>
                {
                    b.Property<int?>("employee_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("employee_id"));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("admin_id")
                        .HasColumnType("int");

                    b.Property<int?>("car_id")
                        .HasColumnType("int");

                    b.Property<int?>("customer_id")
                        .HasColumnType("int");

                    b.Property<string>("employee_FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employee_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employee_gmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("employee_id1")
                        .HasColumnType("int");

                    b.Property<string>("employee_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employee_pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employee_phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employee_position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("invoice_id")
                        .HasColumnType("int");

                    b.HasKey("employee_id");

                    b.HasIndex("admin_id");

                    b.HasIndex("car_id");

                    b.HasIndex("customer_id");

                    b.HasIndex("employee_id1");

                    b.HasIndex("invoice_id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Invoice", b =>
                {
                    b.Property<int?>("invoice_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("invoice_id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalTax")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("invoice_id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("BaseLibrary.Entities.RefreshTokenInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokenInfors");
                });

            modelBuilder.Entity("BaseLibrary.Entities.SystemRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemRoles");
                });

            modelBuilder.Entity("BaseLibrary.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Employee", b =>
                {
                    b.HasOne("BaseLibrary.Entities.Admin", null)
                        .WithMany("Employees")
                        .HasForeignKey("admin_id");

                    b.HasOne("BaseLibrary.Entities.Car", null)
                        .WithMany("Employees")
                        .HasForeignKey("car_id");

                    b.HasOne("BaseLibrary.Entities.Customer", null)
                        .WithMany("Employees")
                        .HasForeignKey("customer_id");

                    b.HasOne("BaseLibrary.Entities.Employee", null)
                        .WithMany("Employees")
                        .HasForeignKey("employee_id1");

                    b.HasOne("BaseLibrary.Entities.Invoice", null)
                        .WithMany("Employees")
                        .HasForeignKey("invoice_id");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Invoice", b =>
                {
                    b.HasOne("BaseLibrary.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("BaseLibrary.Entities.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("BaseLibrary.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Car");

                    b.Navigation("Customers");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Admin", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Car", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Customer", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Employee", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("BaseLibrary.Entities.Invoice", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
