using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Diseases = new SelectList(diseases, "DiseaseID", "DiseaseName");

            var model = new SpecialityWithDiseasesViewModel(); 
            model.SelectedDiseaseIds = new List<int>(); 

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSpeciality(SpecialityWithDiseasesViewModel model)
        {
            if (ModelState.IsValid)
            {
                _speciality.AddSpecialityWithDiseases(model);
                return RedirectToAction("Index", "Speciality");
            }
            var diseases = _disease.GetAllDisease();
            ViewBag.Diseases = diseases;
            return View(model);
        }
        [HttpGet]
        public IActionResult EditSpeciality(int id)
        {
            var speciality = _speciality.GetSpecialityById(id);
            var diseases = _disease.GetAllDisease();
            ViewBag.Diseases = new SelectList(diseases, "DiseaseID", "DiseaseName");

            if (speciality != null)
            {
                SpecialityWithDiseasesViewModel model = new SpecialityWithDiseasesViewModel
                {
                    SpecialityId = speciality.Id,
                    SpecialityName = speciality.SpecialityName,
                    SelectedDiseaseIds = speciality.SpecialtyDiseases.Select(d => d.DiseaseId).ToList()
                };

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditSpeciality(SpecialityWithDiseasesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var speciality = _speciality.GetSpecialityById(model.SpecialityId);

                if (speciality != null)
                {
                    speciality.SpecialityName = model.SpecialityName;

                    // Assuming you have a method to get selected disease IDs from the model
                    var selectedDiseaseIds = model.SelectedDiseaseIds;

                    // Update speciality in the repository
                    _speciality.UpdateSpeciality(model.SpecialityId, speciality, selectedDiseaseIds);

                    return RedirectToAction("Index", "Speciality");
                }

                return NotFound();
            }

            var diseases = _disease.GetAllDisease();
            ViewBag.Diseases = new SelectList(diseases, "DiseaseID", "DiseaseName");
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
