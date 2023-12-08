using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.Models;
using SehatDoc.Services;

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
                _context.SaveChanges();
            }
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            var docs = _context.Doctors.Include(x => x.Speciality).Include(y => y.DoctorHospitalProfiles).ThenInclude(dh => dh.HospitalProfile).ToList();
            return docs;
        }
        //public Doctor GetDoctor(int id)
        //{
        //    var doc = _context.Doctors.Include(x => x.Speciality).FirstOrDefault(x => x.DoctorId == id);
        //    return doc;
        //}
        public Doctor GetDoctor(int id)
        {
            var doc = _context.Doctors
                .Include(x => x.Speciality)
                .Include(x => x.DoctorHospitalProfiles)  // Include DoctorHospitalProfiles
                .FirstOrDefault(x => x.DoctorId == id);
            return doc;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            var doc = _context.Doctors.Attach(doctor);
            doc.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return doctor;
        }
        public IEnumerable<HospitalProfile> GetAllHospitalProfile()
        {
            var doc = _context.HospitalProfiles.ToList();

            return doc;
        }

        public IEnumerable<Doctor> GetSchedule(int id)
        {
            return _context.Doctors.Include(x => x.schedules).ThenInclude(x => x.Hospitals).Where(x => x.DoctorId == id);
        }

       
    }
}
