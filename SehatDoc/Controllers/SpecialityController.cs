using Microsoft.AspNetCore.Mvc;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.SpecialityDTO_s;

namespace SehatDoc.Controllers
{
    public class SpecialityController : Controller
    {
        private readonly ISpecialityInterface _speciality;

        public SpecialityController(ISpecialityInterface speciality)
        {
            this._speciality = speciality;
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
            return View();
        }
        [HttpPost]
        public IActionResult CreateSpeciality(Specialities model)
        {
            if(ModelState.IsValid)
            {
                var speciality = _speciality.AddSpeciality(model);
                return RedirectToAction("Index",new {model.Id});
            }
            ViewBag.Message = "Something Went Wrong";
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
