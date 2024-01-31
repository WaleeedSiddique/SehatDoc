using SehatDoc.DoctorModels;
using SehatDoc.Models;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.ViewModels
{
    public class ApplicationUserViewModel
    {
     //   public string FirstName { get; set; }
        public string Name { get; set; }
       // public string Qualification { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
      //  public string? LicenceNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
       
     //   public int? specialityId { get; set; }

     //public Specialities? Speciality { get; set; }
    }
}
