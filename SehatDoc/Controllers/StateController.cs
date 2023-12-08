using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;

namespace SehatDoc.Controllers
{
    public class StateController : Controller
    {
        private readonly AppDbContext _context;

        public StateController(AppDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetCitiesByState(int stateId)
        {
            var cities = _context.cities.Where(c => c.StateId == stateId).ToList();
            return Json(cities);
        }
    }
}
