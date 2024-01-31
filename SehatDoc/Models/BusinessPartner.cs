using SehatDoc.DoctorEnums;
using SehatDoc.DoctorModels;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class BusinessPartner
    {
        [Key]
        public int BusinessPartnerId { get; set; }
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }
    
        public int? specialityId { get; set; }
      
        public string? LicenseNumber { get; set; }
      
        public Specialities? Speciality { get; set; }
    
        public string? PhotoPath { get; set; }
        
        public Gender? Gender { get; set; }

        public int? CityId { get; set; }
        public int? StateId { get; set; }
       
        public City? City { get; set; }

        public State? State { get; set; }
        public int? UserID { get; set;    }
      
        public ICollection<DoctorHospitalProfile> DoctorHospitalProfiles { get; set; }
        public ICollection<DoctorHospitalSchedule>? schedules { get; set; }
    }
}
