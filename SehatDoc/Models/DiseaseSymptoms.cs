using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class DiseaseSymptoms
    {
        public int SymptomID { get; set; }
        public Symptoms Symptoms { get; set; }
        public int DiseaseID { get; set; }
        public Disease Disease { get; set; }
    }
}
