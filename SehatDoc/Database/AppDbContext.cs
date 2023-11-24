using Microsoft.EntityFrameworkCore;
using SehatDoc.DoctorModels;
using SehatDoc.Models;

namespace SehatDoc.DatabaseContext
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialities> Specialities { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Symptoms> Symptoms { get; set;}
        public DbSet<Department> Departments { get; set; }
        public DbSet<HospitalProfile> HospitalProfiles { get; set; }
        public DbSet<SpecialtyDisease> SpecialtyDiseases { get;set; }
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
        }
    }
}
