using SehatDoc.DoctorModels;

namespace SehatDoc.DoctorInterfaces
{
    public interface IDoctorInteraface
    {
        public IEnumerable<Doctor> GetAllDoctors();
        public Doctor GetDoctor(int id);
        public Doctor UpdateDoctor (Doctor doctor);
        public void DeleteDoctor(int id);
        public Doctor AddDoctor (Doctor doctor);
    }
}
