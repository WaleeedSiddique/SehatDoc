using SehatDoc.DoctorEnums;
using SehatDoc.DoctorModels;
using SehatDoc.Models;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.DoctorDTO_s
{
    public class DoctorDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name is Required")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Speciality must be selected")]
        public int specialityId { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        [Required(ErrorMessage ="Please Add a picture of yourself")]
        public IFormFile PhotoPath { get; set; }
        [Required(ErrorMessage ="Gender Cannot be null")]
        public Gender gender { get; set; }
        [Required(ErrorMessage = "City field is required")]
        public Cities city { get; set; }
        public List<int>? HospitalIDs { get; set; }
        public ICollection<DoctorHospitalSchedule>? HospitalSchedules { get; set; }
    }
}
