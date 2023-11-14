using Microsoft.AspNetCore.Mvc;

namespace SehatDoc.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
