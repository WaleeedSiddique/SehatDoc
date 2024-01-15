﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SehatDoc.DatabaseContext;

#nullable disable

namespace SehatDoc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SehatDoc.DoctorModels.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"), 1L, 1);

                    b.Property<int?>("CityId")
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

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("specialityId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId");

                    b.HasIndex("CityId");

                    b.HasIndex("StateId");

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

            modelBuilder.Entity("SehatDoc.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("HospitalID")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("specialityId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("HospitalID");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("StateId");

                    b.HasIndex("specialityId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SehatDoc.Models.Branch", b =>
                {
                    b.Property<int>("BranchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BranchID"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Contact1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HospitalID")
                        .HasColumnType("int");

                    b.Property<string>("HospitalLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HospitalProfileHospitalID")
                        .HasColumnType("int");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.HasKey("BranchID");

                    b.HasIndex("CityId");

                    b.HasIndex("HospitalProfileHospitalID");

                    b.HasIndex("StateId");

                    b.ToTable("branches");
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

                    b.Property<int?>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("HospitalID")
                        .HasColumnType("int");

                    b.Property<int>("HospitalProfilesHospitalHospitalID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("HospitalProfilesHospitalHospitalID");

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

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("HospitalLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalNumber2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.HasKey("HospitalID");

                    b.HasIndex("CityId");

                    b.HasIndex("StateId");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SehatDoc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SehatDoc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SehatDoc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SehatDoc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SehatDoc.DoctorModels.Doctor", b =>
                {
                    b.HasOne("SehatDoc.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("SehatDoc.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.HasOne("SehatDoc.DoctorModels.Specialities", "Speciality")
                        .WithMany("doctors")
                        .HasForeignKey("specialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Speciality");

                    b.Navigation("State");
                });

            modelBuilder.Entity("SehatDoc.Models.ApplicationUser", b =>
                {
                    b.HasOne("SehatDoc.Models.City", "City")
                        .WithMany("ApplicationUser")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SehatDoc.Models.HospitalProfile", "hospitalprofile")
                        .WithMany("ApplicationUser")
                        .HasForeignKey("HospitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SehatDoc.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SehatDoc.DoctorModels.Specialities", "Speciality")
                        .WithMany("ApplicationUser")
                        .HasForeignKey("specialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Speciality");

                    b.Navigation("State");

                    b.Navigation("hospitalprofile");
                });

            modelBuilder.Entity("SehatDoc.Models.Branch", b =>
                {
                    b.HasOne("SehatDoc.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("SehatDoc.Models.HospitalProfile", "HospitalProfile")
                        .WithMany()
                        .HasForeignKey("HospitalProfileHospitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SehatDoc.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("City");

                    b.Navigation("HospitalProfile");

                    b.Navigation("State");
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
                    b.HasOne("SehatDoc.Models.Branch", "HospitalBranch")
                        .WithMany("DepartmentHospitalProfiles")
                        .HasForeignKey("BranchID");

                    b.HasOne("SehatDoc.Models.Department", "DepartmentsDepartment")
                        .WithMany("DepartmentHospitalProfiles")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SehatDoc.Models.HospitalProfile", "HospitalProfilesHospital")
                        .WithMany("DepartmentHospitalProfiles")
                        .HasForeignKey("HospitalProfilesHospitalHospitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartmentsDepartment");

                    b.Navigation("HospitalBranch");

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

            modelBuilder.Entity("SehatDoc.Models.HospitalProfile", b =>
                {
                    b.HasOne("SehatDoc.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("SehatDoc.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("City");

                    b.Navigation("State");
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
                    b.Navigation("ApplicationUser");

                    b.Navigation("SpecialtyDiseases");

                    b.Navigation("doctors");
                });

            modelBuilder.Entity("SehatDoc.Models.Branch", b =>
                {
                    b.Navigation("DepartmentHospitalProfiles");
                });

            modelBuilder.Entity("SehatDoc.Models.City", b =>
                {
                    b.Navigation("ApplicationUser");
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
                    b.Navigation("ApplicationUser");

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
