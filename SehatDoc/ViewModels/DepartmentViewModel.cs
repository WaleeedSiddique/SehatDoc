using System.ComponentModel.DataAnnotations;

namespace SehatDoc.ViewModels
{
    public class DepartmentViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string DepartmentName { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentDescription { get; set; }
    }
}
