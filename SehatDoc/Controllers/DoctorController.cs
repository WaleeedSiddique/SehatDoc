using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
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
        private readonly AppDbContext _context;

        public DoctorController
            (IDoctorInteraface doctorInteraface,IHostingEnvironment hosting,ISpecialityInterface speciality, AppDbContext context)
        {
            this._doctorInteraface = doctorInteraface;
            this._hosting = hosting;
            this._speciality = speciality;
            this._context = context;
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
        public IActionResult GetAllDoctors()
        {
            var doctors = _doctorInteraface.GetAllDoctors();
            var specialites = _speciality.GetAllSpecialities();
            ViewBag.speciality = new SelectList(specialites, "Id", "SpecialityName");
            return View(doctors);
        }
        [HttpGet]
        public IActionResult DoctorProfile(int id)
        {
            var doc = _doctorInteraface.GetDoctorProfile(id);
            var schedules = _doctorInteraface.GetDoctorHospitalSchedules(id);
            
            doc.schedules =schedules;
            
            return View(doc);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var speclities = _speciality.GetAllSpecialities();
            var hospitals = _doctorInteraface.GetAllHospitalProfile();
            ViewBag.Specialities = new SelectList(speclities, "Id", "SpecialityName");
            ViewBag.HospitalProfile = new SelectList(hospitals, "HospitalID", "HospitalName");
            var states = _context.states.ToList();
            ViewBag.states = new SelectList(states, "Id", "StateName");
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
                        uniqueName = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                        string filepath = Path.Combine(imagefolder, uniqueName);
                        model.PhotoPath.CopyTo(new FileStream(filepath, FileMode.Create));
                   
                }
                Doctor newDoc = new Doctor()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    LicenseNumber = model.LicenseNumber,
                    CityId = model.CityId,
                    StateId = model.StateId,
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
            var speclities = _speciality.GetAllSpecialities();
            var hospitals = _doctorInteraface.GetAllHospitalProfile();
            ViewBag.Specialities = new SelectList(speclities, "Id", "SpecialityName");
            ViewBag.HospitalProfile = new SelectList(hospitals, "HospitalID", "HospitalName");

            var states = _context.states.ToList();
            ViewBag.states = new SelectList(states, "Id", "StateName");
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
                    CityId = doc.CityId,
                    StateId = doc.StateId,
                    specialityId = (int)doc.specialityId,
                    gender = (DoctorEnums.Gender)doc.Gender,
                    HospitalIDs = doc.DoctorHospitalProfiles?.Select(dhp => dhp.HospitalID ?? 0).ToList() ?? new List<int>(),
                };
               
                ViewBag.Specialities = new SelectList(speclities, "Id", "SpecialityName");

                ViewBag.HospitalProfile = new MultiSelectList(hospitals, "HospitalID", "HospitalName", model.HospitalIDs); // Use MultiSelectList for multiple selection

                ViewBag.States = new SelectList(_context.states.ToList(), "Id", "StateName");

                var cities = _context.cities.Where(x => x.StateId == doc.StateId);
                ViewBag.Cities = new SelectList(cities, "Id", "CityName", doc.CityId);
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
                if (doc != null)
                {
                    doc.FirstName = model.FirstName;
                    doc.LastName = model.LastName;
                    doc.LicenseNumber = model.LicenseNumber;
                    doc.CityId = model.CityId;
                    doc.StateId = model.StateId;
                    doc.Gender = model.gender;
                    doc.specialityId = model.specialityId;

                    if (model.HospitalIDs != null && model.HospitalIDs.Any())
                    {
                        doc.DoctorHospitalProfiles = model.HospitalIDs
                            .Select(hospitalID => new DoctorHospitalProfile { HospitalID = hospitalID })
                            .ToList();
                    }
                    else
                    {
                        // If no hospitals are selected, you might want to clear existing associations
                        doc.DoctorHospitalProfiles = new List<DoctorHospitalProfile>();
                    }
                    _doctorInteraface.UpdateDoctor(doc);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            var speclities = _speciality.GetAllSpecialities();
            var hospitals = _doctorInteraface.GetAllHospitalProfile();
            ViewBag.Specialities = new SelectList(speclities, "Id", "SpecialityName");
            ViewBag.HospitalProfile = new MultiSelectList(hospitals, "HospitalID", "HospitalName", model.HospitalIDs); // Use MultiSelectList for multiple selection
            var states = _context.states.ToList();
            ViewBag.states = new SelectList(states, "Id", "StateName");
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
        [HttpGet]
        public IActionResult GetSchedule(int id)
        {
            var schedules = _doctorInteraface.GetSchedule(id);
            return View(schedules);
        }

    }
}
