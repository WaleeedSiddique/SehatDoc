using System.ComponentModel.DataAnnotations;

namespace SehatDoc.ViewModels
{
    public class SpecialityWithDiseasesViewModel
    {
        public int SpecialityId { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string SpecialityName { get; set; }
        [Required(ErrorMessage = "Disease is Required")]
        public List<int> SelectedDiseaseIds { get; set; }
    }
}
