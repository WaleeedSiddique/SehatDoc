using SehatDoc.Models;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.DepartmentDTO_s
{
    public class DepartmentDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name")]
        [StringLength(20)]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Please Write Summarized Description.")]
        [StringLength(50)]

        public string DepartmentDescription { get; set; }
   
    }
}
