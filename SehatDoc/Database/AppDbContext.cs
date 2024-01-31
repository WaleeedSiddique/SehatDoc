using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SehatDoc.DoctorModels;
using SehatDoc.Models;

namespace SehatDoc.DatabaseContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialities> Specialities { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Symptoms> Symptoms { get; set;}
        public DbSet<Department> Departments { get; set; }
        public DbSet<HospitalProfile> HospitalProfiles { get; set; }
        public DbSet<SpecialtyDisease> SpecialtyDiseases { get;set; }
        public DbSet<DepartmentHospitalProfile> DepartmentHospitalProfile { get;set; }
        public DbSet<DoctorHospitalProfile> DoctorHospitalProfile { get;set; }
        public DbSet<DiseaseSymptoms> DiseaseSymptoms { get;set; }
        public DbSet<DoctorHospitalSchedule> schedules { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<BusinessPartner> businessPartners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecialtyDisease>()
                .HasKey(sd => new { sd.SpecialtyId, sd.DiseaseId });

            modelBuilder.Entity<SpecialtyDisease>()
                .HasOne(sd => sd.Specialty)
                .WithMany(s => s.SpecialtyDiseases)
                .HasForeignKey(sd => sd.SpecialtyId);

            modelBuilder.Entity<SpecialtyDisease>()
                .HasOne(sd => sd.Disease)
                .WithMany(d => d.SpecialtyDiseases)
                .HasForeignKey(sd => sd.DiseaseId);

            modelBuilder.Entity<DiseaseSymptoms>()
                .HasKey(ds => new { ds.DiseaseID, ds.SymptomID });

            modelBuilder.Entity<DiseaseSymptoms>()
            .HasOne(ds => ds.Symptoms)
            .WithMany(a => a.DiseaseSymptoms)
            .HasForeignKey(ds => ds.SymptomID);

            modelBuilder.Entity<DiseaseSymptoms>()
             .HasOne(ds => ds.Disease)
             .WithMany(a => a.DiseaseSymptoms)
             .HasForeignKey(ds => ds.DiseaseID);

            modelBuilder.Entity<DoctorHospitalProfile>()
                .HasKey(dhp => new { dhp.DoctorID, dhp.HospitalID });

            modelBuilder.Entity<DoctorHospitalProfile>()
                .HasOne(dhp => dhp.Doctor)
                .WithMany(d => d.DoctorHospitalProfiles)
                .HasForeignKey(dhp => dhp.DoctorID);

            modelBuilder.Entity<DoctorHospitalProfile>()
                .HasOne(dhp => dhp.HospitalProfile)
                .WithMany(hp => hp.DoctorHospitalProfiles)
                .HasForeignKey(dhp => dhp.HospitalID);

            modelBuilder.Entity<DoctorHospitalSchedule>()
             .HasKey(dhs => dhs.id);

            modelBuilder.Entity<DoctorHospitalSchedule>()
                .HasOne(dhs => dhs.Doctor)
                .WithMany(d => d.schedules)
                .HasForeignKey(dhs => dhs.doctorId);

            modelBuilder.Entity<DoctorHospitalSchedule>()
                .HasOne(dhs => dhs.Hospitals)
                .WithMany(h => h.schedules)
                .HasForeignKey(dhs => dhs.HospitalId);

            modelBuilder.Entity<DoctorHospitalSchedule>()
            .HasOne(dhs => dhs.Doctor)
            .WithMany(d => d.schedules)
            .HasForeignKey(dhs => dhs.doctorId);


            //nullable properties
          
             modelBuilder.Entity<Doctor>()
             .Property(e => e.LicenseNumber)
             .IsRequired(false);

            modelBuilder.Entity<Doctor>()
        .Property(e => e.specialityId)
        .IsRequired(false);  // Make specialityId nullable in the database

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Speciality)
                .WithMany()  // Assuming Speciality has a collection navigation property pointing back to Doctor
                .HasForeignKey(d => d.specialityId)
                .IsRequired();

            modelBuilder.Entity<Doctor>()
            .Property(e => e.PhotoPath)
            .IsRequired(false);

            modelBuilder.Entity<Doctor>()
           .Property(e => e.Gender)
           .IsRequired(false);

            modelBuilder.Entity<Doctor>()
        .Property(e => e.CityId)
        .IsRequired(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.StateId)
                .IsRequired(false);

            modelBuilder.Entity<Doctor>()
      .Property(e => e.Email)
      .IsRequired(false);

            modelBuilder.Entity<Doctor>()
      .Property(e => e.ApplicationUserId)
      .IsRequired(false);

            base.OnModelCreating(modelBuilder);

        }
    }
}
