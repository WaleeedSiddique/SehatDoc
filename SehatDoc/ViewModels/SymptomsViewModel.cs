﻿using System.ComponentModel.DataAnnotations;

namespace SehatDoc.ViewModels
{
    public class SymptomsViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string SymptomName { get; set; }

        [Required]
        public IFormFile SymptomImage { get; set; }


        [Required]
        [StringLength(50)]
        public string SymptomDescription { get; set; }
    }
}
