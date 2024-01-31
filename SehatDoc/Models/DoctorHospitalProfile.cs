using SehatDoc.DoctorModels;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class DoctorHospitalProfile
    {
   
        public int? HospitalID { get; set; }
        public HospitalProfile HospitalProfile { get; set; }

        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
       
    }
}
