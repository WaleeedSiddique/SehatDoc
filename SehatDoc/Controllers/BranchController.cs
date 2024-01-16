using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SehatDoc.BranchInterfaces;
using SehatDoc.DatabaseContext;
using SehatDoc.DepartmentInterfaces;
using SehatDoc.DoctorInterfaces;
using SehatDoc.HospitalProfileDTO_s;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.Models;
using SehatDoc.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SehatDoc.Controllers
{
    public class BranchController : Controller
    {
        private readonly IHospitalProfileInterface _hospitalProfileInterface;
        private readonly IHostingEnvironment _hosting;
        private readonly IDepartmentInterface _department;
        private readonly AppDbContext _context;
        private readonly IDoctorInteraface _doctor;
        private readonly IBranchInterface _branch;
        public BranchController
           (IHospitalProfileInterface hospitalProfileInteraface,IBranchInterface branch, IHostingEnvironment hosting, IDepartmentInterface department, AppDbContext context)
        {
            this._hospitalProfileInterface = hospitalProfileInteraface;
            this._hosting = hosting;
            this._department = department;
            this._context = context;
            this._branch = branch;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BranchDetail(int hospitalID)
        {
            var branchdetail = _branch.GetBranchesForHospital(hospitalID);
            return PartialView("_BranchDetail", branchdetail);
        }
        [HttpGet]
        public IActionResult AddBranch(int hospitalId)
        {
            var dept = _department.GetAllDepartment();
            ViewBag.Departments = new SelectList(dept, "DepartmentID", "DepartmentName");
            var states = _context.states.ToList();
            ViewBag.States = new SelectList(states, "Id", "StateName");            

            // Create an instance of BranchViewModel and pass the hospitalId
            var branchViewModel = new BranchViewModel(hospitalId);

            // Return the partial view with the populated ViewModel
            return PartialView("_BranchPartialView", branchViewModel);
        }
        [HttpPost]
        public IActionResult AddBranch(BranchViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Branch newBranch = new Branch()
                {
                     
                    Location = viewModel.Location,
                    Contact1 = viewModel.Contact1,
                    Contact2 = viewModel.Contact2,
                    CityId = viewModel.CityId,
                    hospitalid = viewModel.HospitalID,
                    BranchName = viewModel.BranchName,

                    StateId = viewModel.StateId
                };

                // Associate Department with Hospitals
                //if (viewModel.DepartmentIDs != null && viewModel.DepartmentIDs.Any())
                //{
                //    newDoc.DepartmentHospitalProfiles = viewModel.DepartmentIDs
                //        .Select(departmentID => new DepartmentHospitalProfile { DepartmentID = departmentID })
                //        .ToList();
                //}

                var doc = _branch.AddBranch(newBranch);

               // return RedirectToAction("Index", new { id = doc.HospitalID });
                return RedirectToAction("Index", "HospitalProfile");
            }
            var dept = _department.GetAllDepartment();
            ViewBag.Departments = new SelectList(dept, "DepartmentID", "DepartmentName");
            var states = _context.states.ToList();
            ViewBag.states = new SelectList(states, "Id", "StateName");
            return View();
        }
        [HttpGet]
        public IActionResult EditBranch(int id)
        {
            var branch = _branch.GetBranch(id);
            if (branch != null)
            {
                BranchViewModel model = new BranchViewModel()
                {
                    BranchName = branch.BranchName,
                    Location = branch.Location,
                    Contact1 = branch.Contact1,
                    Contact2 = branch.Contact2,
                    CityId = branch.CityId,
                    StateId = branch.StateId,
                    HospitalID = branch.hospitalid
                };

              
                ViewBag.States = new SelectList(_context.states.ToList(), "Id", "StateName");

                var cities = _context.cities.Where(x => x.StateId == branch.StateId);
                ViewBag.Cities = new SelectList(cities, "Id", "CityName", branch.CityId);

                return PartialView("_EditBranchPartialView", model);
            }
            return NotFound();
         
        }
        [HttpPost]
        public IActionResult EditBranch(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var branch = _branch.GetBranch(model.ID);
                if (branch != null)
                {
                    branch.BranchName = model.BranchName;
                    branch.Location = model.Location;
                    branch.Contact1 = model.Contact1;
                    branch.Contact2 = model.Contact2;
                    branch.CityId = model.CityId;
                    branch.StateId = model.StateId;


                    _branch.UpdateBranch(branch);
                    return RedirectToAction("Index","HospitalProfile");
                }

                // return View(model);
                return PartialView("_BranchDetail", model);
            }
            
            var states = _context.states.ToList();
            ViewBag.states = new SelectList(states, "Id", "StateName");
            return View("Index",model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var branch = _branch.GetBranchesForHospital(id);
            if (branch != null)
            {
                _branch.DeleteBranch(id);
                return RedirectToAction("Index", "HospitalProfile");
            }
            return NotFound();
        }
    }
}
