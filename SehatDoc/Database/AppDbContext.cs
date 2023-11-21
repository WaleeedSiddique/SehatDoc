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
    }
}
