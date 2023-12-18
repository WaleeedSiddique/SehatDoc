using System.ComponentModel.DataAnnotations;

namespace SehatDoc.DiseaseDTO_s
{
    public class DiseaseDTO
    {

        
        public int ID { get; set; }

        [Required(ErrorMessage = "Disease Name is required.")]
        [StringLength(20)]
        public string DiseaseName { get; set; }

        [Required]
        public IFormFile DiseaseImage { get; set; }
        [Required(ErrorMessage = "Please Write Summarized Description")]
       
        public string DiseaseDescription { get; set; }
        [Required(ErrorMessage = "Please Add at least one symptom")]
        public List<int> SymptomsIDs { get; set; }
    }
}
