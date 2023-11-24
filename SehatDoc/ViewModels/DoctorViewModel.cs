using SehatDoc.DoctorEnums;
using SehatDoc.DoctorModels;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.DoctorDTO_s
{
    public class DoctorViewModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        public int specialityId { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        [Required]
        public IFormFile PhotoPath { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public Cities city { get; set; }
    }
}
