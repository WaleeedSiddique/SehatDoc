using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class Branch
    {
        public int BranchID { get; set; }
        public int HospitalID { get; set; }
        public HospitalProfile HospitalProfile { get; set; }
        [Required]
        public string HospitalLocation { get; set; }
        [Required]
        public string Contact1 { get; set; }
        [Required]

        public string Contact2 { get; set; }
      
        public int? CityId { get; set; }
        public int? StateId { get; set; }

        public City City { get; set; }

        public State State { get; set; }
        public virtual ICollection<DepartmentHospitalProfile> DepartmentHospitalProfiles { get; set; }
    }
}
