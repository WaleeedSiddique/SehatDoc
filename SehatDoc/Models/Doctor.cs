using SehatDoc.DoctorEnums;
using SehatDoc.Models;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.DoctorModels
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "The FirstName field is required.")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "The LastName field is required.")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "The Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "The Speciality field is required.")]

        public int? specialityId { get; set; }
        [Required(ErrorMessage = "The License Number field is required.")]
        public string LicenseNumber { get; set; }
        [Required(ErrorMessage = "The Speciality field is required.")]
        public Specialities Speciality { get; set; }
        [Required(ErrorMessage = "The Image  is required.")]
        public string PhotoPath { get; set; }
        [Required(ErrorMessage = "The Gender is required.")]
        public Gender? Gender { get; set; }
        [Required(ErrorMessage = "The City field is required.")]
        public int? CityId { get; set; }
        [Required(ErrorMessage = "The State field is required.")]
        public int? StateId { get; set; }

        public City City { get; set; }

        public State State { get; set; }

        public  ICollection<DoctorHospitalProfile> DoctorHospitalProfiles { get; set; }
        public ICollection<DoctorHospitalSchedule>? schedules { get; set; }

        public string? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
