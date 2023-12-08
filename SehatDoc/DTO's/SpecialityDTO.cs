using System.ComponentModel.DataAnnotations;

namespace SehatDoc.SpecialityDTO_s
{
    public class SpecialityDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Speciality Name is Required")] 
        
        public string name {  get; set; }

    }
}
