using Microsoft.AspNetCore.Identity;
using SehatDoc.DoctorModels;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
   

    }
}
