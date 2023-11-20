using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class Symptoms
    {
        [Key]
        public int SymptomID { get; set; }

        [Required]
        [StringLength(20)]
        public string SymptomName { get; set; }

        [Required]
        public string  SymptomImage { get; set; }

        [Required]
        [StringLength(50)]
        public string SymptomDescription { get; set; }

    }
}
