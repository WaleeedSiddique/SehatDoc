using Microsoft.AspNetCore.Identity;
using SehatDoc.DoctorModels;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Qualification { get; set; }
        
        [Required]
        public int ?specialityId { get; set; }
        public Specialities Speciality { get; set; }
        [Required]
        public int? CityId { get; set; }
        [Required]
        public int? StateId { get; set; }

        public City City { get; set; }
       
        public State State { get; set; }
        [Required]
        public int HospitalID { get; set; }
        public HospitalProfile hospitalprofile { get; set; }

    }
}
