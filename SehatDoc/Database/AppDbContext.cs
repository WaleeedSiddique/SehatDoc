using Microsoft.EntityFrameworkCore;
using SehatDoc.DoctorModels;

namespace SehatDoc.DatabaseContext
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialities> Specialities { get; set; }
    }
}
