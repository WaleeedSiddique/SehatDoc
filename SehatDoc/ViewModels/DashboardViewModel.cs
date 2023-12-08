using SehatDoc.DoctorModels;
using SehatDoc.Models;
using SehatDoc.SpecialityDTO_s;

namespace SehatDoc.ViewModels
{
    public class DashboardViewModel
    {
        public ICollection<DoctorHospitalProfile> DoctorHospitalProfiles { get; set; }
        public Specialities specialities { get; set; }
        public ICollection<Doctor>? doctors { get; set; }
        public int TotalDoctorCount { get; set; }
        public int TotalHospitalCount { get; set; }
        public List<HospitalProfile> Hospitals { get; set; }



    }
}
