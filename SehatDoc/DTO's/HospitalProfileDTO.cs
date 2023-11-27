using SehatDoc.DoctorEnums;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.HospitalProfileDTO_s
{
    public class HospitalProfileDTO
    {
        public int ID { get; set; }
        [Required]
        [StringLength(30)]
        public string HospitalName { get; set; }
        [Required]
        [StringLength(50)]
        public string HospitalLocation { get; set; }
        [Required]
        public string HospitalNumber { get; set; }
        [Required]
        public IFormFile HospitalLogo { get; set; }
        public List<int> DepartmentIDs { get; set; }
        public List<int> DoctorIDs { get; set; }
        [Required]
        public Cities city { get; set; }
      
    }
}
