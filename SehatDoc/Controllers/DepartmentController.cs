using Microsoft.AspNetCore.Mvc;
using SehatDoc.DepartmentInterfaces;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using SehatDoc.Models;
using SehatDoc.DepartmentDTO_s;

namespace SehatDoc.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IHostingEnvironment _hosting;
        private readonly IDepartmentInterface _departmentInterface;


        public DepartmentController
            (IDepartmentInterface departmentInteraface, IHostingEnvironment hosting)
        {
            this._departmentInterface = departmentInteraface;
            this._hosting = hosting;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentInterface.GetAllDepartment();
            return View(department);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _departmentInterface.GetDepartment(id);
            if (department != null)
            {
                return View(department);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult ListDisease()
        {
            var department = _departmentInterface.GetAllDepartment();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
             
                Department newDep = new Department()
                {
                    DepartmentName = model.DepartmentName,
                    DepartmentDescription = model.DepartmentDescription
                };
                var department = _departmentInterface.AddDepartment(newDep);
                return RedirectToAction("Index", new { newDep.DepartmentID });
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _departmentInterface.GetDepartment(id);

            if (department != null)
            {
                DepartmentDTO model = new DepartmentDTO()
                {
                    DepartmentName = department.DepartmentName,
                    DepartmentDescription = department.DepartmentDescription


                };

                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(DepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                var department = _departmentInterface.GetDepartment(model.ID);
                if (department != null)
                {
                    department.DepartmentName = model.DepartmentName;
                    department.DepartmentDescription = model.DepartmentDescription;

                    _departmentInterface.UpdateDepartment(department);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentInterface.GetDepartment(id);
            if (department != null)
            {
                _departmentInterface.DeleteDepartment(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
