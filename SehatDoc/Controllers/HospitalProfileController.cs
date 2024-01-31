using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SehatDoc.DatabaseContext;
using SehatDoc.DepartmentInterfaces;
using SehatDoc.DoctorDTO_s;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.HospitalProfileDTO_s;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SehatDoc.Controllers
{
    public class HospitalProfileController : Controller
    {
        private readonly IHospitalProfileInterface _hospitalProfileInterface;
        private readonly IHostingEnvironment _hosting;
        private readonly IDepartmentInterface _department;
        private readonly AppDbContext _context;
        private readonly IDoctorInteraface _doctor;

        public HospitalProfileController
            (IHospitalProfileInterface hospitalProfileInteraface, IHostingEnvironment hosting, IDepartmentInterface department, IDoctorInteraface doctor,AppDbContext context)
        {
            this._hospitalProfileInterface = hospitalProfileInteraface;
            this._hosting = hosting;
            this._department = department;
            this._doctor = doctor;
            this._context = context;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var hospital = _hospitalProfileInterface.GetAllHospitalProfile();
            return View(hospital);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var hospital = _hospitalProfileInterface.GetHospitalProfilewithbranch(id);
            if (hospital != null)
            {
                return View(hospital);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult ListHospitalProfile()
        {
            var hospital = _hospitalProfileInterface.GetAllHospitalProfile();
            var dept = _department.GetAllDepartment();
            ViewBag.department = new SelectList(dept, "DepartmentID", "DepartmentName");
            return View(hospital);
        }
        [HttpGet]
        public IActionResult GetAllHospitalProfile()
        {
            var hospital = _hospitalProfileInterface.GetAllHospitalProfile();
            return View(hospital);
        }
        [HttpGet]
        public IActionResult HospitalProfile(int id)
        {
            var hospital = _hospitalProfileInterface.HospitalProfile(id);
            var schedules = _hospitalProfileInterface.GetHospitalDoctorSchedules(id);

            hospital.schedules = schedules;

            return View(hospital);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var dept = _department.GetAllDepartment();
            ViewBag.Departments = new SelectList(dept, "DepartmentID", "DepartmentName");
            var states = _context.states.ToList();
            ViewBag.states = new SelectList(states, "Id", "StateName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(HospitalProfileDTO model)
        {
            if (ModelState.IsValid)
            {
                string uniqueName = null;
                if (model.HospitalLogo != null)
                {
                    var imagefolder = Path.Combine(_hosting.WebRootPath, "images");
                    uniqueName = Guid.NewGuid().ToString() + "_" + model.HospitalLogo.FileName;
                    string filepath = Path.Combine(imagefolder, uniqueName);
                    model.HospitalLogo.CopyTo(new FileStream(filepath, FileMode.Create));
                }

                // Create HospitalProfile entity
                HospitalProfile newDoc = new HospitalProfile()
                {
                    HospitalName = model.HospitalName,
                    HospitalLocation = model.HospitalLocation,
                    HospitalNumber = model.HospitalNumber,
                    HospitalNumber2 = model.HospitalNumber2,
                    CityId = model.CityId,
                    HospitalLogo = uniqueName,
                    StateId = model.StateId
                };

                // Associate Department with Hospitals
                if (model.DepartmentIDs != null && model.DepartmentIDs.Any())
                {
                    newDoc.DepartmentHospitalProfiles = model.DepartmentIDs
                        .Select(departmentID => new DepartmentHospitalProfile { DepartmentID = departmentID })
                        .ToList();
                }

                var doc = _hospitalProfileInterface.AddHospitalProfile(newDoc);

                return RedirectToAction("Index", new { id = doc.HospitalID });
            }
            var dept = _department.GetAllDepartment();
            ViewBag.Departments = new SelectList(dept, "DepartmentID", "DepartmentName");
            var states = _context.states.ToList();
            ViewBag.states = new SelectList(states, "Id", "StateName");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hospital = _hospitalProfileInterface.GetHospitalProfile(id);
            var departments = _department.GetAllDepartment();

           
            if (hospital != null)
            {
                HospitalProfileDTO model = new HospitalProfileDTO()
                {
                    HospitalName = hospital.HospitalName,
                    HospitalLocation = hospital.HospitalLocation,
                    HospitalNumber = hospital.HospitalNumber,
                    HospitalNumber2 = hospital.HospitalNumber2,
                    CityId = hospital.CityId,
                    StateId = hospital.StateId,
                    DepartmentIDs = hospital.DepartmentHospitalProfiles.Select(dhp => dhp.DepartmentID).ToList(),

                };

                ViewBag.Departments = new SelectList(departments, "DepartmentID", "DepartmentName", model.DepartmentIDs);
                ViewBag.States = new SelectList(_context.states.ToList(), "Id", "StateName");

                var cities = _context.cities.Where(x => x.StateId == hospital.StateId);
                ViewBag.Cities = new SelectList(cities, "Id", "CityName", hospital.CityId);

                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(HospitalProfileDTO model)
        {
            if (ModelState.IsValid)
            {
                var hospital = _hospitalProfileInterface.GetHospitalProfile(model.ID);
                if (hospital != null)
                {
                    hospital.HospitalName = model.HospitalName;
                    hospital.HospitalLocation = model.HospitalLocation;
                    hospital.HospitalNumber = model.HospitalNumber;
                    hospital.HospitalNumber2 = model.HospitalNumber2;
                    hospital.CityId = model.CityId;
                    hospital.StateId = model.StateId;

                    //Update associated departments
                    if (model.DepartmentIDs != null && model.DepartmentIDs.Any())
                    {
                        hospital.DepartmentHospitalProfiles = model.DepartmentIDs
                            .Select(departmentID => new DepartmentHospitalProfile { DepartmentID = departmentID })
                            .ToList();
                    }
                    else
                    {
                        // If no departments are selected, you may want to clear the existing associations.
                        hospital.DepartmentHospitalProfiles.Clear();
                    }

                    _hospitalProfileInterface.UpdateHospitalProfile(hospital);
                    return RedirectToAction("Index");
                }
                var departments = _department.GetAllDepartment();
                ViewBag.Departments = new SelectList(departments, "DepartmentID", "DepartmentName", model.DepartmentIDs);
                return View(model);
            }
            var dept = _department.GetAllDepartment();
            ViewBag.Departments = new SelectList(dept, "DepartmentID", "DepartmentName");
            var states = _context.states.ToList();
            ViewBag.states = new SelectList(states, "Id", "StateName");
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var hospital = _hospitalProfileInterface.GetHospitalProfile(id);
            if (hospital != null)
            {
                _hospitalProfileInterface.DeleteHospitalProfile(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
     
        [HttpGet]
        public IActionResult GetHospitalsByCity(int cityId)
        {
            var hospitals = _context.HospitalProfiles.Where(c => c.CityId == cityId).ToList();
            return Json(hospitals);
        }


    }
}
