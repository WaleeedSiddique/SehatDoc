using SehatDoc.DoctorEnums;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.DoctorModels
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
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
        public Specialities Speciality { get; set; }
        [Required]
        public string PhotoPath { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Cities City { get; set; }
    }
}
