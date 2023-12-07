﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SehatDoc.DatabaseContext;

#nullable disable

namespace SehatDoc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231207145459_validationsadded")]
    partial class validationsadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SehatDoc.DoctorModels.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"), 1L, 1);

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("specialityId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId");

                    b.HasIndex("specialityId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("SehatDoc.DoctorModels.Specialities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SpecialityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("SehatDoc.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("SehatDoc.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"), 1L, 1);

                    b.Property<string>("DepartmentDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SehatDoc.Models.DepartmentHospitalProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentsDepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("HospitalProfilesHospitalID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentsDepartmentID");

                    b.HasIndex("HospitalProfilesHospitalID");

                    b.ToTable("DepartmentHospitalProfile");
                });

            modelBuilder.Entity("SehatDoc.Models.Disease", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseID"), 1L, 1);

                    b.Property<string>("DiseaseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiseaseImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DiseaseID");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("SehatDoc.Models.DiseaseSymptoms", b =>
                {
                    b.Property<int>("DiseaseID")
                        .HasColumnType("int");

                    b.Property<int>("SymptomID")
                        .HasColumnType("int");

                    b.HasKey("DiseaseID", "SymptomID");

                    b.HasIndex("SymptomID");

                    b.ToTable("DiseaseSymptoms");
                });

            modelBuilder.Entity("SehatDoc.Models.DoctorHospitalProfile", b =>
                {
                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int?>("HospitalID")
                        .HasColumnType("int");

                    b.HasKey("DoctorID", "HospitalID");

                    b.HasIndex("HospitalID");

                    b.ToTable("DoctorHospitalProfile");
                });

            modelBuilder.Entity("SehatDoc.Models.DoctorHospitalSchedule", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("doctorId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("doctorId");

                    b.ToTable("schedules");
                });

            modelBuilder.Entity("SehatDoc.Models.HospitalProfile", b =>
                {
                    b.Property<int>("HospitalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospitalID"), 1L, 1);

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("HospitalLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("HospitalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalNumber2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("HospitalID");

                    b.ToTable("HospitalProfiles");
                });

            modelBuilder.Entity("SehatDoc.Models.SpecialtyDisease", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.HasKey("SpecialtyId", "DiseaseId");

                    b.HasIndex("DiseaseId");

                    b.ToTable("SpecialtyDiseases");
                });

            modelBuilder.Entity("SehatDoc.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("states");
                });

            modelBuilder.Entity("SehatDoc.Models.Symptoms", b =>
                {
                    b.Property<int>("SymptomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SymptomID"), 1L, 1);

                    b.Property<string>("SymptomDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SymptomImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SymptomName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SymptomID");

                    b.ToTable("Symptoms");
                });

            modelBuilder.Entity("SehatDoc.DoctorModels.Doctor", b =>
                {
                    b.HasOne("SehatDoc.DoctorModels.Specialities", "Speciality")
                        .WithMany("doctors")
                        .HasForeignKey("specialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("SehatDoc.Models.City", b =>
                {
                    b.HasOne("SehatDoc.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("SehatDoc.Models.DepartmentHospitalProfile", b =>
                {
                    b.HasOne("SehatDoc.Models.Department", "DepartmentsDepartment")
                        .WithMany("DepartmentHospitalProfiles")
                        .HasForeignKey("DepartmentsDepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SehatDoc.Models.HospitalProfile", "HospitalProfilesHospital")
                        .WithMany("DepartmentHospitalProfiles")
                        .HasForeignKey("HospitalProfilesHospitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartmentsDepartment");

                    b.Navigation("HospitalProfilesHospital");
                });

            modelBuilder.Entity("SehatDoc.Models.DiseaseSymptoms", b =>
                {
                    b.HasOne("SehatDoc.Models.Disease", "Disease")
                        .WithMany("DiseaseSymptoms")
                        .HasForeignKey("DiseaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SehatDoc.Models.Symptoms", "Symptoms")
                        .WithMany("DiseaseSymptoms")
                        .HasForeignKey("SymptomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");

                    b.Navigation("Symptoms");
                });

            modelBuilder.Entity("SehatDoc.Models.DoctorHospitalProfile", b =>
                {
                    b.HasOne("SehatDoc.DoctorModels.Doctor", "Doctor")
                        .WithMany("DoctorHospitalProfiles")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SehatDoc.Models.HospitalProfile", "HospitalProfile")
                        .WithMany("DoctorHospitalProfiles")
                        .HasForeignKey("HospitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("HospitalProfile");
                });

            modelBuilder.Entity("SehatDoc.Models.DoctorHospitalSchedule", b =>
                {
                    b.HasOne("SehatDoc.Models.HospitalProfile", "Hospitals")
                        .WithMany("schedules")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SehatDoc.DoctorModels.Doctor", "Doctor")
                        .WithMany("schedules")
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Hospitals");
                });

            modelBuilder.Entity("SehatDoc.Models.SpecialtyDisease", b =>
                {
                    b.HasOne("SehatDoc.Models.Disease", "Disease")
                        .WithMany("SpecialtyDiseases")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SehatDoc.DoctorModels.Specialities", "Specialty")
                        .WithMany("SpecialtyDiseases")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("SehatDoc.DoctorModels.Doctor", b =>
                {
                    b.Navigation("DoctorHospitalProfiles");

                    b.Navigation("schedules");
                });

            modelBuilder.Entity("SehatDoc.DoctorModels.Specialities", b =>
                {
                    b.Navigation("SpecialtyDiseases");

                    b.Navigation("doctors");
                });

            modelBuilder.Entity("SehatDoc.Models.Department", b =>
                {
                    b.Navigation("DepartmentHospitalProfiles");
                });

            modelBuilder.Entity("SehatDoc.Models.Disease", b =>
                {
                    b.Navigation("DiseaseSymptoms");

                    b.Navigation("SpecialtyDiseases");
                });

            modelBuilder.Entity("SehatDoc.Models.HospitalProfile", b =>
                {
                    b.Navigation("DepartmentHospitalProfiles");

                    b.Navigation("DoctorHospitalProfiles");

                    b.Navigation("schedules");
                });

            modelBuilder.Entity("SehatDoc.Models.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("SehatDoc.Models.Symptoms", b =>
                {
                    b.Navigation("DiseaseSymptoms");
                });
#pragma warning restore 612, 618
        }
    }
}
