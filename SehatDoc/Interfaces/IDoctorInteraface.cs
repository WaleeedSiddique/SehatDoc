using SehatDoc.DoctorModels;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.Models;

namespace SehatDoc.DoctorInterfaces
{
    public interface IDoctorInteraface
    {
        public IEnumerable<HospitalProfile> GetAllHospitalProfile();
        public IEnumerable<Doctor> GetAllDoctors();
        public Doctor GetDoctor(int id);
        public Doctor UpdateDoctor (Doctor doctor);
        public void DeleteDoctor(int id);
        public Doctor AddDoctor (Doctor doctor);
    }
}
