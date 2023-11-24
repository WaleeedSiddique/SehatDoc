using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class Disease
    {
        [Key]
        public int DiseaseID { get; set; }

        [Required]
        [StringLength(20)]
        public string DiseaseName { get; set; }

        [Required]
        public string DiseaseImage { get; set; }
        public ICollection<SpecialtyDisease> SpecialtyDiseases { get; set; }
    }
}
