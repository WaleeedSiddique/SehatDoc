using System.ComponentModel.DataAnnotations;

namespace SehatDoc.ViewModels
{
    public class DiseaseViewModel
    {


        public int DiseaseID { get; set; }

        [Required]
        [StringLength(20)]
        public string DiseaseName { get; set; }

        [Required]
        public IFormFile DiseaseImage { get; set; }
    }
}

