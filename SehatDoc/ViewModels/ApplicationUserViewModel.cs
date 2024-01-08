using SehatDoc.Models;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Name { get; set; }
        public string Qualification { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        [Required]
        public int? specialityId { get; set; }

        public int? CityId { get; set; }
        public int? StateId { get; set; }
        
        public int HospitalID { get; set; }
    }
}
