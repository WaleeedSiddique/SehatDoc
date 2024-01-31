using SehatDoc.DoctorEnums;
using SehatDoc.DoctorModels;
using SehatDoc.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SehatDoc.DoctorDTO_s
{
    public class DoctorDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Last Name is Required")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Speciality must be selected")]
        public int specialityId { get; set; }
      
        [Required(ErrorMessage = "License Number is Required")]
        public string LicenseNumber { get; set; }
        [Required(ErrorMessage ="Please Add a picture of yourself")]
       
        public IFormFile PhotoPath { get; set; }
        [Required(ErrorMessage ="Gender Cannot be null")]
        public Gender gender { get; set; }
        [Required(ErrorMessage = "City field is required")]
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public City? city { get; set; }
 
        public State? state { get; set; }
        public List<int>? HospitalIDs { get; set; }
        public ICollection<DoctorHospitalSchedule>? HospitalSchedules { get; set; }

        // Foreign key to ApplicationUser
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
