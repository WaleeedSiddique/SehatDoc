using SehatDoc.DoctorModels;
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
        [StringLength(50)]
        public string HospitalLocation { get; set; }
        [Required]
        public string HospitalNumber { get; set; }
        [Required]
        public string HospitalLogo { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

    }
}
