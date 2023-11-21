﻿// <auto-generated />
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
    [Migration("20231120123103_HospitalProfile")]
    partial class HospitalProfile
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

            modelBuilder.Entity("SehatDoc.Models.Disease", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseID"), 1L, 1);

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

            modelBuilder.Entity("SehatDoc.Models.HospitalProfile", b =>
                {
                    b.Property<int>("HospitalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospitalID"), 1L, 1);

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("HospitalLocation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.HasKey("HospitalID");

                    b.ToTable("HospitalProfiles");
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

            modelBuilder.Entity("SehatDoc.DoctorModels.Specialities", b =>
                {
                    b.Navigation("doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
