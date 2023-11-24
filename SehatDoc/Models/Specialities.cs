using SehatDoc.Models;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.DoctorModels
{
    public class Specialities
    {
        [Key]
        public int Id { get; set; }
        public string SpecialityName { get; set; }
        public ICollection<Doctor>? doctors { get; set; }


        public ICollection<SpecialtyDisease>? SpecialtyDiseases { get; set; }

    }
}
