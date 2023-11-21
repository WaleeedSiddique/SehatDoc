using System.ComponentModel.DataAnnotations;

namespace SehatDoc.ViewModels
{
    public class HospitalProfileViewModel
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
        public int DepartmentID { get; set; }

    }
}
