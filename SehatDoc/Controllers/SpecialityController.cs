using Microsoft.AspNetCore.Mvc;
using SehatDoc.DiseaseInterfaces;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.Models;
using SehatDoc.SpecialityDTO_s;
using SehatDoc.ViewModels;

namespace SehatDoc.Controllers
{
    public class SpecialityController : Controller
    {
        private readonly ISpecialityInterface _speciality;
        private readonly IDiseaseInterface _disease;

        public SpecialityController(ISpecialityInterface speciality, IDiseaseInterface disease)
        {
            this._speciality = speciality;
            this._disease = disease;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var specialities = _speciality.GetAllSpecialities();
            return View(specialities);
        }
        [HttpGet]
        public IActionResult SpecialityDetails(int id)
        {
            var speciality = _speciality.GetSpecialityById(id);
            return View(speciality);  
        }
        [HttpGet]
        public IActionResult CreateSpeciality()
        {
            var diseases = _disease.GetAllDisease();
            ViewBag.Diseases = diseases;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpeciality(SpecialityWithDiseasesViewModel model)
        {
            if (ModelState.IsValid)
            {
                _speciality.AddSpecialityWithDiseases(model);
                return RedirectToAction("Index", "Home");
            }
            var diseases = _disease.GetAllDisease();
            ViewBag.Diseases = diseases;
            return View(model);
        }
        [HttpGet]
        public IActionResult EditSpeciality(int id)
        {
            var speciality = _speciality.GetSpecialityById(id);
            if(speciality != null)
            {
                SpecialityDTO model = new SpecialityDTO()
                {
                    name = speciality.SpecialityName
                };
                return View(model); 
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult EditSpeciality(SpecialityDTO model)
        {
            if(ModelState.IsValid)
            {
                var speciality = _speciality.GetSpecialityById(model.id);
                if (speciality != null)
                {
                    speciality.SpecialityName = model.name;
                    _speciality.UpdateSpeciality(speciality);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteSpeciality(int id)
        {
            var speciality = _speciality.GetSpecialityById(id);
            if(speciality != null)
            {
                _speciality.DeleteSpeciality(speciality);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
       
    }
}
