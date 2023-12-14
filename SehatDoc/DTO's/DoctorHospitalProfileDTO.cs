using SehatDoc.DoctorModels;
using SehatDoc.Models;

namespace SehatDoc.DTO_s
{
    public class DoctorHospitalProfileDTO
    {
        public int ID { get; set; }

        public int HospitalID { get; set; }
        public HospitalProfile Hospital { get; set; }

        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
    }
}
