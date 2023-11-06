using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;

namespace SehatDoc.DoctorRepositories
{
    public class SpecialityService : ISpecialityInterface
    {
        private readonly AppDbContext _context;

        public SpecialityService(AppDbContext context)
        {
            this._context = context;
        }
        public Specialities AddSpeciality(Specialities speciality)
        {
            var model = _context.Specialities.Add(speciality);
            _context.SaveChanges();
            return speciality;
        } 

        public Specialities DeleteSpeciality(Specialities speciality)
        {
            var model = _context.Specialities.FirstOrDefault(x => x.Id == speciality.Id);
            if(model != null)
            {
                _context.Specialities.Remove(model);
                _context.SaveChanges();
            }
            return speciality;
        }

        public IEnumerable<Specialities> GetAllSpecialities()
        {
            var specialities = _context.Specialities.Include(x => x.doctors).ToList();
            return specialities;
        }

        public Specialities GetSpecialityById(int id)
        {
            var speciality = _context.Specialities.Include(x => x.doctors).FirstOrDefault(x => x.Id == id);
            return speciality;
        }

        public Specialities UpdateSpeciality(Specialities SpecialityChanges)
        {
            var speciality = _context.Specialities.Attach(SpecialityChanges);
            speciality.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return SpecialityChanges;
        }
    }
}
