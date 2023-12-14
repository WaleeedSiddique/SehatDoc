namespace SehatDoc.ViewModels
{
    public class SpecialityWithDiseasesViewModel
    {
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
        public List<int> SelectedDiseaseIds { get; set; }
    }
}
