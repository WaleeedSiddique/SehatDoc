using System.ComponentModel.DataAnnotations;

namespace SehatDoc.DiseaseDTO_s
{
    public class DiseaseDTO
    {

        
        public int DiseaseID { get; set; }

        [Required]
        [StringLength(20)]
        public string DiseaseName { get; set; }

        [Required]
        public IFormFile DiseaseImage { get; set; }
    }
}
