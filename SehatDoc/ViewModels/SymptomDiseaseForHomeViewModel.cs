using SehatDoc.Models;
using System.ComponentModel.DataAnnotations;

namespace SehatDoc.ViewModels
{
    public class SymptomDiseaseForHomeViewModel
    {
        public List<Symptoms> Symptoms { get; set; }
        public List<Disease> Diseases { get; set; }

    }
}
