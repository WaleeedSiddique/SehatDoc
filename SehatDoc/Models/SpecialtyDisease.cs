using SehatDoc.DoctorModels;

namespace SehatDoc.Models
{
    public class SpecialtyDisease
    {
        public int SpecialtyId { get; set; }
        public Specialities Specialty { get; set; }
        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
    }
}
