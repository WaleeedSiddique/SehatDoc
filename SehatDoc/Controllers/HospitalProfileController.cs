using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public HospitalProfileController
            (IHospitalProfileInterface hospitalProfileInteraface, IHostingEnvironment hosting, IDepartmentInterface department)
        {
            this._hospitalProfileInterface = hospitalProfileInteraface;
            this._hosting = hosting;
            this._department = department;
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
            var hospital = _hospitalProfileInterface.GetHospitalProfile(id);
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
        public IActionResult Create()
        {
            var dept = _department.GetAllDepartment();
            ViewBag.Departments = new SelectList(dept, "DepartmentID", "DepartmentName");
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
                HospitalProfile newHospital = new HospitalProfile()
                {
                    HospitalName = model.HospitalName,
                    HospitalLocation = model.HospitalLocation,
                    HospitalNumber = model.HospitalNumber,
                    DepartmentID = model.DepartmentID,
                    HospitalLogo = uniqueName
                };
                var hospital = _hospitalProfileInterface.AddHospitalProfile(newHospital);
                return RedirectToAction("Index", new { newHospital.HospitalID });
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hospital = _hospitalProfileInterface.GetHospitalProfile(id);
            var department = _department.GetAllDepartment();
            if (hospital != null)
            {
                HospitalProfileDTO model = new HospitalProfileDTO()
                {
                    HospitalName = hospital.HospitalName,
                    HospitalLocation = hospital.HospitalLocation,
                    HospitalNumber = hospital.HospitalLocation, 
                    DepartmentID = hospital.DepartmentID,
                
                };
                ViewBag.Departments = new SelectList(department, "DepartmentID", "DepartmentName");
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
                    hospital.DepartmentID = model.DepartmentID;
                    _hospitalProfileInterface.UpdateHospitalProfile(hospital);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
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
      

    }
}
