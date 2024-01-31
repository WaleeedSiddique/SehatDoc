using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SehatDoc.DatabaseContext;
using SehatDoc.DiseaseInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.SymptomsInterfaces;
using SehatDoc.ViewModels;
using System.Diagnostics;

namespace SehatDoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISymptomsInterface _symptom;
        private readonly IDiseaseInterface _disease;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger,ISymptomsInterface symptomInterface,IDiseaseInterface disease, AppDbContext context)
        {
            _logger = logger;
            this._symptom = symptomInterface;
            this._disease = disease;
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new SymptomDiseaseForHomeViewModel
            {
                Symptoms = (List<Models.Symptoms>)_symptom.GetAllSymptoms(),
                Diseases = (List<Models.Disease>)_disease.GetAllDisease()
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}