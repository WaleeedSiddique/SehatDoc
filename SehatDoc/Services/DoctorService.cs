using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;

namespace SehatDoc.DoctorRepositories
{
    public class DoctorService : IDoctorInteraface
    {
        private readonly AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            this._context = context;
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            var doc = _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public void DeleteDoctor(int id)
        {
            var doc = _context.Doctors.FirstOrDefault(x => x.DoctorId == id);
            if(doc != null)
            {
                _context.Doctors.Remove(doc);
            }
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            var docs = _context.Doctors.Include(x => x.Speciality).ToList();
            return docs;
        }

        public Doctor GetDoctor(int id)
        {
            var doc = _context.Doctors.Include(x => x.Speciality).FirstOrDefault(x => x.DoctorId == id);
            return doc;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            var doc = _context.Doctors.Attach(doctor);
            doc.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return doctor;
        }
    }
}
