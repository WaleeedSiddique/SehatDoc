using Microsoft.AspNetCore.Mvc;
using SehatDoc.DoctorDTO_s;

namespace SehatDoc.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
       
    }
}
