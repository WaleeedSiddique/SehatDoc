using System.ComponentModel.DataAnnotations;

namespace SehatDoc.ViewModels
{
    public class DiseasesWithSymptomsViewModel
    {
        public string DiseaseName { get; set; }

       // [Required]
        public IFormFile DiseaseImage { get; set; }
        public List<int> SymptomsIDs { get; set; }
    }
}
