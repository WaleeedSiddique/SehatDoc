using SehatDoc.DoctorModels;
using SehatDoc.Models;

namespace SehatDoc.ViewModels
{
    public class SpecialityCountViewModel
    {
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
       
        public int DoctorCount { get; set; }
        public ICollection<Doctor>? doctors { get; set; }
    }
}
