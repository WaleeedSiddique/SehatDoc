using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SehatDoc.DoctorDTO_s;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SehatDoc.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorInteraface _doctorInteraface;
        private readonly IHostingEnvironment _hosting;
        private readonly ISpecialityInterface _speciality;
        private readonly IHospitalProfileInterface _hospital;

        public DoctorController
            (IDoctorInteraface doctorInteraface,IHostingEnvironment hosting,ISpecialityInterface speciality)
        {
            this._doctorInteraface = doctorInteraface;
            this._hosting = hosting;
            this._speciality = speciality;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Doctors = _doctorInteraface.GetAllDoctors();
            return View(Doctors);   
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var doc = _doctorInteraface.GetDoctor(id);
            if(doc != null)
            {
                return View(doc);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult ListDoctors()
        {
            var doctors = _doctorInteraface.GetAllDoctors();
            var specialites = _speciality.GetAllSpecialities();
            ViewBag.speciality = new SelectList(specialites, "Id", "SpecialityName");
            return View(doctors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var speclities = _speciality.GetAllSpecialities();
            var hospitals = _doctorInteraface.GetAllHospitalProfile();
            ViewBag.Specialities = new SelectList(speclities, "Id", "SpecialityName");
            ViewBag.HospitalProfile = new SelectList(hospitals, "HospitalID", "HospitalName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(DoctorDTO model)
        {
            if (ModelState.IsValid)
            {
                string uniqueName = null;
                if (model.PhotoPath != null)
                {
                    var imagefolder = Path.Combine(_hosting.WebRootPath, "images");
                    uniqueName = Guid.NewGuid().ToString()+ "_" + model.PhotoPath.FileName;
                    string filepath = Path.Combine(imagefolder, uniqueName);
                    model.PhotoPath.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                Doctor newDoc = new Doctor()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    LicenseNumber = model.LicenseNumber,
                    City = model.city,
                    Gender = model.gender,
                    specialityId = model.specialityId,
                    PhotoPath = uniqueName
                };
                if (model.HospitalIDs != null && model.HospitalIDs.Any())
                {
                    newDoc.DoctorHospitalProfiles = model.HospitalIDs
                        .Select(hospitalID => new DoctorHospitalProfile { HospitalID = hospitalID })
                        .ToList();
                }
                var doc = _doctorInteraface.AddDoctor(newDoc);
                return RedirectToAction("Index", new {newDoc.DoctorId});                
            }
            return View();
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var doc = _doctorInteraface.GetDoctor(id);
            var speclities = _speciality.GetAllSpecialities();
            var hospitals = _doctorInteraface.GetAllHospitalProfile();
            if (doc != null)
            {
                DoctorDTO model = new DoctorDTO()
                {
                    FirstName = doc.FirstName,
                    LastName = doc.LastName,
                    LicenseNumber = doc.LicenseNumber,
                    city = doc.City,
                    specialityId = doc.specialityId,
                    gender = doc.Gender,

                 //  HospitalIDs = doc.DoctorHospitalProfiles?.Select(dhp => dhp.HospitalID).ToList(),
                };
                ViewBag.Specialities = new SelectList(speclities, "Id", "SpecialityName");
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(DoctorDTO model)
        {
            if (ModelState.IsValid)
            {
            var doc = _doctorInteraface.GetDoctor(model.id);
                if(doc != null)
                {
                    doc.FirstName = model.FirstName;
                    doc.LastName = model.LastName;
                    doc.LicenseNumber = model.LicenseNumber;
                    doc.City = model.city;
                    doc.Gender = model.gender;
                    doc.specialityId = model.specialityId;
                    _doctorInteraface.UpdateDoctor(doc);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var doc = _doctorInteraface.GetDoctor(id);
            if (doc != null)
            {
                _doctorInteraface.DeleteDoctor(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult DoctorsinCategory(string name)
        {
            var doctors = _doctorInteraface.GetAllDoctors().Where(x => x.Speciality.SpecialityName == name).ToList();
            return View(doctors);
        }
       
    }
}
