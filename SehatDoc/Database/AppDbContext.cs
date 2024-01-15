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

            //
            // Configure ApplicationUser and HospitalProfile relationship
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.hospitalprofile)
                .WithMany(h => h.ApplicationUser)
                .HasForeignKey(u => u.HospitalID)
                .IsRequired(); // If HospitalID is required

            modelBuilder.Entity<ApplicationUser>()
           .HasOne(u => u.State)
           .WithMany()
           .HasForeignKey(u => u.StateId)
           .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);

        }
    }
}
