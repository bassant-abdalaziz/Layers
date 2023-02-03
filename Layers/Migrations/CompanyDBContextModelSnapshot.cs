﻿// <auto-generated />
using System;
using Layers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Layers.Migrations
{
    [DbContext(typeof(CompanyDBContext))]
    partial class CompanyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Layers.Models.Department", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("mngrSSN")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("mngrSSN")
                        .IsUnique()
                        .HasFilter("[mngrSSN] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Layers.Models.DepartmentLocation", b =>
                {
                    b.Property<int>("DeptNumber")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DeptNumber", "Location");

                    b.ToTable("DepartmentLocation");
                });

            modelBuilder.Entity("Layers.Models.Dependent", b =>
                {
                    b.Property<int>("EmpSSN")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Relationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpSSN", "Name");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("Layers.Models.Employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Minit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupervisorSSN")
                        .HasColumnType("int");

                    b.Property<int?>("deptId")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("SupervisorSSN");

                    b.HasIndex("deptId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Layers.Models.Project", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<int?>("DeptNum")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.HasIndex("DeptNum");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Layers.Models.WorksOnProject", b =>
                {
                    b.Property<int>("EmpSSN")
                        .HasColumnType("int");

                    b.Property<int>("projNum")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeesSSN")
                        .HasColumnType("int");

                    b.Property<string>("Hours")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpSSN", "projNum");

                    b.HasIndex("EmployeesSSN");

                    b.HasIndex("projNum");

                    b.ToTable("WorksOnProjects");
                });

            modelBuilder.Entity("Layers.Models.Department", b =>
                {
                    b.HasOne("Layers.Models.Employee", "employeeManege")
                        .WithOne("DepartmentManege")
                        .HasForeignKey("Layers.Models.Department", "mngrSSN");

                    b.Navigation("employeeManege");
                });

            modelBuilder.Entity("Layers.Models.DepartmentLocation", b =>
                {
                    b.HasOne("Layers.Models.Department", "Department")
                        .WithMany("DepartmentLocations")
                        .HasForeignKey("DeptNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Layers.Models.Dependent", b =>
                {
                    b.HasOne("Layers.Models.Employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("EmpSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Layers.Models.Employee", b =>
                {
                    b.HasOne("Layers.Models.Employee", "Supervisor")
                        .WithMany("Employees")
                        .HasForeignKey("SupervisorSSN");

                    b.HasOne("Layers.Models.Department", "DepartmentWork")
                        .WithMany("EmployeesWork")
                        .HasForeignKey("deptId");

                    b.Navigation("DepartmentWork");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("Layers.Models.Project", b =>
                {
                    b.HasOne("Layers.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DeptNum");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Layers.Models.WorksOnProject", b =>
                {
                    b.HasOne("Layers.Models.Employee", "Employees")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("EmployeesSSN");

                    b.HasOne("Layers.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("projNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Layers.Models.Department", b =>
                {
                    b.Navigation("DepartmentLocations");

                    b.Navigation("EmployeesWork");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Layers.Models.Employee", b =>
                {
                    b.Navigation("DepartmentManege");

                    b.Navigation("Dependents");

                    b.Navigation("Employees");

                    b.Navigation("WorksOnProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
