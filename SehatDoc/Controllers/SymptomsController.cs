using Microsoft.AspNetCore.Mvc;
using SehatDoc.SymptomsDTO_s;
using SehatDoc.SymptomsInterfaces;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using SehatDoc.Models;


namespace SehatDoc.Controllers
{
    public class SymptomsController : Controller
    {

        private readonly IHostingEnvironment _hosting;
        private readonly ISymptomsInterface _symptomsInterface;


        public SymptomsController
            (ISymptomsInterface symptomsInteraface, IHostingEnvironment hosting)
        {
            this._symptomsInterface = symptomsInteraface;
            this._hosting = hosting;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var symptoms = _symptomsInterface.GetAllSymptoms();
            return View(symptoms);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var symptoms = _symptomsInterface.GetSymptom(id);
            if (symptoms != null)
            {
                return View(symptoms);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult ListDisease()
        {
            var symptoms = _symptomsInterface.GetAllSymptoms();
            return View(symptoms);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SymptomsDTO model)
        {
            if (ModelState.IsValid)
            {
                string uniqueName = null;
                if (model.SymptomImage != null)
                {
                    var imagefolder = Path.Combine(_hosting.WebRootPath, "images");
                    uniqueName = Guid.NewGuid().ToString() + "_" + model.SymptomImage.FileName;
                    string filepath = Path.Combine(imagefolder, uniqueName);
                    model.SymptomImage.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                Symptoms newSymptom = new Symptoms()
                {
                    SymptomName = model.SymptomName,
                    SymptomImage = uniqueName,
                    SymptomDescription = model.SymptomDescription
                };
                var symptoms = _symptomsInterface.AddSymptoms(newSymptom);
                return RedirectToAction("Index", new { newSymptom.SymptomID });
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var symptoms = _symptomsInterface.GetSymptom(id);

            if (symptoms != null)
            {
                SymptomsDTO model = new SymptomsDTO()
                {
                    id = symptoms.SymptomID,
                    SymptomName = symptoms.SymptomName,
                    SymptomDescription = symptoms.SymptomDescription
                   



                };
               

                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(SymptomsDTO model)
        {
            if (ModelState.IsValid)
            {
                var symptoms = _symptomsInterface.GetSymptom(model.id);
                if (symptoms != null)
                {
                    symptoms.SymptomName = model.SymptomName;
                    symptoms.SymptomDescription = model.SymptomDescription;

                    _symptomsInterface.UpdateSymptom(symptoms);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View(model);

        }
        //[HttpPost]
        //public IActionResult Edit(SymptomsDTO model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var existingSymptom = _symptomsInterface.GetSymptom(model.id);

        //        if (existingSymptom != null)
        //        {
        //            existingSymptom.SymptomName = model.SymptomName;
        //            existingSymptom.SymptomDescription = model.SymptomDescription;

        //            if (model.SymptomImage != null)
        //            {
        //                // Delete existing image file if it exists
        //                if (!string.IsNullOrEmpty(existingSymptom.SymptomImage))
        //                {
        //                    var imagePath = Path.Combine(_hosting.WebRootPath, "images", existingSymptom.SymptomImage);
        //                    if (System.IO.File.Exists(imagePath))
        //                    {
        //                        System.IO.File.Delete(imagePath);
        //                    }
        //                }

        //                // Save new image
        //                var imageFolder = Path.Combine(_hosting.WebRootPath, "images");
        //                var uniqueName = Guid.NewGuid().ToString() + "_" + model.SymptomImage.FileName;
        //                var filePath = Path.Combine(imageFolder, uniqueName);
        //                model.SymptomImage.CopyTo(new FileStream(filePath, FileMode.Create));

        //                existingSymptom.SymptomImage = uniqueName;
        //            }

        //            _symptomsInterface.UpdateSymptom(existingSymptom);
        //            return RedirectToAction("Index");
        //        }

        //        return View(model);
        //    }

        //    return View(model);
        //}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var symptoms = _symptomsInterface.GetSymptom(id);
            if (symptoms != null)
            {
                _symptomsInterface.DeleteSymptoms(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
