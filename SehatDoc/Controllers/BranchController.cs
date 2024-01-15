using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SehatDoc.BranchInterfaces;
using SehatDoc.DatabaseContext;
using SehatDoc.DepartmentInterfaces;
using SehatDoc.DoctorInterfaces;
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
        //public IActionResult BranchDetail(int hospitalId)
        //{
        //    var branchdetail = _branch.GetBranchesForHospital(hospitalId);
        //    return PartialView("_BranchDetail",branchdetail);
        //}
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

                Branch newDoc = new Branch()
                {
                     
                    Location = viewModel.Location,
                    Contact1 = viewModel.Contact1,
                    Contact2 = viewModel.Contact2,
                    CityId = viewModel.CityId,
                    hospitalid = 1,
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

                var doc = _branch.AddBranch(newDoc);

               // return RedirectToAction("Index", new { id = doc.HospitalID });
                return RedirectToAction("Index", "HospitalProfile");
            }
            var dept = _department.GetAllDepartment();
            ViewBag.Departments = new SelectList(dept, "DepartmentID", "DepartmentName");
            var states = _context.states.ToList();
            ViewBag.states = new SelectList(states, "Id", "StateName");
            return View();
        }
    }
}
