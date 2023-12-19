using SehatDoc.DoctorEnums;
using SehatDoc.Enums;
using SehatDoc.Models;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.HospitalProfileDTO_s
{
    public class HospitalProfileDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Hospital Name is required.")]
        [StringLength(30)]
        public string HospitalName { get; set; }
        [Required(ErrorMessage = "Hospital Location is required.")]
        public string HospitalLocation { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number should contain only numbers.")]
        [MaxLength(11, ErrorMessage = "Phone number should not exceed 11 digits.")]
        public string HospitalNumber { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number should contain only numbers.")]
        [MaxLength(11, ErrorMessage = "Phone number should not exceed 11 digits.")]
        public string HospitalNumber2 { get; set; }
        [Required(ErrorMessage = "Please Add a Hospital Logo")]
        public IFormFile HospitalLogo { get; set; }
        [Required(ErrorMessage = "Please Select Departments.")]
        public List<int> DepartmentIDs { get; set; }
    
       // [Required(ErrorMessage = "City Field is required.")]
       public int? CityId { get; set; }
        public int? StateId { get; set; }
        public City? city { get; set; }
       // [Required(ErrorMessage = "Please Select State.")]
        public State? state { get; set; }
    }
}
