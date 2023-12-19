using System.ComponentModel.DataAnnotations;

namespace SehatDoc.SymptomsDTO_s
{
    public class SymptomsDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Symptom Name is Required")]
        [StringLength(20)]
        public string SymptomName { get; set; }

        [Required(ErrorMessage = "Please Add a Symptom Image")]
        public IFormFile SymptomImage { get; set; }
        

        [Required(ErrorMessage ="Please Enter Summarized Description")]
        [StringLength(50)]
        public string SymptomDescription { get; set; }
    }
}
