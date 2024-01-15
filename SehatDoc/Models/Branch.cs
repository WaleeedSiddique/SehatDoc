using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }
        public string BranchName { get; set; }  
        public int hospitalid { get; set; }
        public HospitalProfile? hospital {  get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Contact1 { get; set; }
        [Required]

        public string Contact2 { get; set; }
      
        public int? CityId { get; set; }
        public int? StateId { get; set; }

        public City? City { get; set; }

        public State? State { get; set; }
        //public virtual ICollection<DepartmentHospitalProfile> DepartmentHospitalProfiles { get; set; }
    }
}
