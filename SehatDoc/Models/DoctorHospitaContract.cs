using SehatDoc.DoctorModels;

namespace SehatDoc.Models
{
    public class DoctorHospitaContract
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public HospitalProfile HospitalProfile { get; set; }
        public int doctorId { get; set; }
        public Doctor doctor { get; set; }
    }
}
