using SehatDoc.DoctorEnums;
using SehatDoc.DoctorModels;
using SehatDoc.DoctorRepositories;
using SehatDoc.Enums;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class HospitalProfile
    {
        [Key]
        public int HospitalID { get; set; }
        [Required]
        [StringLength(30)]
        public string HospitalName { get; set; }
        [Required]
        public string HospitalLocation { get; set; }
        [Required]
        public string HospitalNumber { get; set; }
        [Required]
        
        public string HospitalNumber2 { get; set; }
        [Required]
        public string HospitalLogo { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        
        public City City { get; set; }
       
        public State State { get; set; }
        public ICollection<DoctorHospitalProfile> DoctorHospitalProfiles { get; set; }
        public virtual ICollection<DepartmentHospitalProfile> DepartmentHospitalProfiles { get; set; }
        public ICollection<DoctorHospitalSchedule>? schedules { get; set; }

       
    }

}

