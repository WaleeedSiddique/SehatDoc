using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required]
        [StringLength(20)]
        public string DepartmentName { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmentDescription { get; set; }

        public virtual ICollection<DepartmentHospitalProfile> DepartmentHospitalProfiles { get; set; }
      
    }
}
