﻿// <auto-generated />
using System;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfrastructureLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250304104550_InitialCreate22")]
    partial class InitialCreate22
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainLayer.Entity.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier")
                        .HasColumnName("AttendanceID");

                    b.Property<DateTime>("CheckInTime")
                        .HasColumnType("DATETIME2");

                    b.Property<DateTime?>("CheckOutTime")
                        .HasColumnType("DATETIME2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<TimeSpan?>("TotalWorkingHours")
                        .HasColumnType("time");

                    b.HasKey("Id")
                        .HasName("PK_AttendanceId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("DomainLayer.Entity.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR(150)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DomainLayer.Entity.LeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier")
                        .HasColumnName("LeaveRequestID");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR(500)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id")
                        .HasName("PK_LeaveRequestId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("DomainLayer.Entity.Attendance", b =>
                {
                    b.HasOne("DomainLayer.Entity.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DomainLayer.Entity.LeaveRequest", b =>
                {
                    b.HasOne("DomainLayer.Entity.Employee", "Employee")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DomainLayer.Entity.Employee", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("LeaveRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
