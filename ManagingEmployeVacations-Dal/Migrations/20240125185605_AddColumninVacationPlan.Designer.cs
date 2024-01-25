﻿// <auto-generated />
using System;
using ManagingEmployeVacations_Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagingEmployeVacations_Dal.Migrations
{
    [DbContext(typeof(VacationContext))]
    [Migration("20240125185605_AddColumninVacationPlan")]
    partial class AddColumninVacationPlan
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VacationBalance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.RequestVacation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateApproved")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRequestVacation")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDateVacations")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDateVacations")
                        .HasColumnType("datetime2");

                    b.Property<int>("VacationTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VacationTypeId");

                    b.ToTable("RequestsVacation");
                });

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.VacationDatePlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("VacationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VacationRequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VacationRequestId");

                    b.ToTable("VacationsDatePlan");
                });

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.VacationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Background_Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VacationsType");
                });

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.Employee", b =>
                {
                    b.HasOne("ManagingEmployeVacations_Dal.Entites.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.RequestVacation", b =>
                {
                    b.HasOne("ManagingEmployeVacations_Dal.Entites.Employee", "Employee")
                        .WithMany("RequestVacations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManagingEmployeVacations_Dal.Entites.VacationType", "VacationType")
                        .WithMany("RequestVacations")
                        .HasForeignKey("VacationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("VacationType");
                });

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.VacationDatePlan", b =>
                {
                    b.HasOne("ManagingEmployeVacations_Dal.Entites.RequestVacation", "VacationRequest")
                        .WithMany("VacationDatePlan")
                        .HasForeignKey("VacationRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VacationRequest");
                });

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.Employee", b =>
                {
                    b.Navigation("RequestVacations");
                });

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.RequestVacation", b =>
                {
                    b.Navigation("VacationDatePlan");
                });

            modelBuilder.Entity("ManagingEmployeVacations_Dal.Entites.VacationType", b =>
                {
                    b.Navigation("RequestVacations");
                });
#pragma warning restore 612, 618
        }
    }
}
