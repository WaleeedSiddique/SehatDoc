using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SehatDoc.DiseaseDTO_s;
using SehatDoc.DiseaseInterfaces;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using SehatDoc.Models;
using SehatDoc.DoctorDTO_s;
using SehatDoc.DoctorInterfaces;

namespace SehatDoc.Controllers
{
    public class DiseaseController : Controller
    {
     
        private readonly IHostingEnvironment _hosting;
        private readonly IDiseaseInterface _diseaseInterface;
        

        public DiseaseController
            (IDiseaseInterface diseaseInteraface, IHostingEnvironment hosting)
        {
            this._diseaseInterface = diseaseInteraface;
            this._hosting = hosting;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Disease = _diseaseInterface.GetAllDisease();
            return View(Disease);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var disease = _diseaseInterface.GetDisease(id);
            if (disease != null)
            {
                return View(disease);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult ListDisease()
        {
            var disease = _diseaseInterface.GetAllDisease();
            return View(disease);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DiseaseDTO model)
        {
            if (ModelState.IsValid)
            {
                string uniqueName = null;
                if (model.DiseaseImage != null)
                {
                    var imagefolder = Path.Combine(_hosting.WebRootPath, "images");
                    uniqueName = Guid.NewGuid().ToString() + "_" + model.DiseaseImage.FileName;
                    string filepath = Path.Combine(imagefolder, uniqueName);
                    model.DiseaseImage.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                Disease newDoc = new Disease()
                {
                    DiseaseName = model.DiseaseName,
                    DiseaseImage = uniqueName
                };
                var disease = _diseaseInterface.AddDisease(newDoc);
                return RedirectToAction("Index", new { newDoc.DiseaseID });
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var disease = _diseaseInterface.GetDisease(id);
            
            if (disease != null)
            {
                DiseaseDTO model = new DiseaseDTO()
                {
                    DiseaseName = disease.DiseaseName
                    
                   
                };
                
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(DiseaseDTO model)
        {
            if (ModelState.IsValid)
            {
                var disease = _diseaseInterface.GetDisease(model.ID);
                if (disease != null)
                {
                    disease.DiseaseName = model.DiseaseName;
                  
                    _diseaseInterface.UpdateDisease(disease);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var disease = _diseaseInterface.GetDisease(id);
            if (disease != null)
            {
                _diseaseInterface.DeleteDisease(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
