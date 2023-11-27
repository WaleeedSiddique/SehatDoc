using SehatDoc.DoctorModels;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class DoctorHospitalProfile
    {
        [Key]
        public int DoctorHospitalProfileID { get; set; }

        public int HospitalID { get; set; }
        public HospitalProfile Hospital { get; set; }

        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
    }
}
