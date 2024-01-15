using SehatDoc.Models;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.ViewModels
{
    public class BranchViewModel
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public int HospitalID { get; set; }
       // public HospitalProfile HospitalProfile { get; set; }
        [Required]
        public string Location { get; set; }
        [Required(ErrorMessage = "Contact 1 is required.")]
        //[RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Invalid phone number. Please enter an 11-digit number.")]
        public string Contact1 { get; set; }
        [Required(ErrorMessage = "Contact 2 is required.")]
        //[RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Invalid phone number. Please enter an 11-digit number.")]

        public string Contact2 { get; set; }

        public int? CityId { get; set; }
        public int? StateId { get; set; }

       // public City City { get; set; }

       // public State State { get; set; }
        //public List<int> DepartmentIDs { get; set; }
        //public virtual ICollection<DepartmentHospitalProfile> DepartmentHospitalProfiles { get; set; }
    public BranchViewModel(int hospitalId)
    {
        HospitalID = hospitalId;
    }
        public BranchViewModel()
        {
            // Initialize properties or any other logic if needed.
        }
    }
}
