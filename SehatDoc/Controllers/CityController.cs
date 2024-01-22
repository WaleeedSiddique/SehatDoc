using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorDTO_s;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.DTO_s;
using SehatDoc.Interfaces;
using SehatDoc.Models;
using SehatDoc.SymptomsDTO_s;
using SehatDoc.SymptomsInterfaces;

namespace SehatDoc.Controllers
{
    public class CityController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IStateInterface _stateInterface;
        private readonly ICityInterface _cityInterface;

        public CityController(AppDbContext context, IStateInterface _state, ICityInterface cityInterface)
        {
            this._context = context;
            this._stateInterface = _state;
            this._cityInterface = cityInterface;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var city = _cityInterface.GetAllCity();
            return View(city);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var state = _stateInterface.GetAllState();
            ViewBag.States= new SelectList(state, "Id", "StateName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CityDTO model)
        {
            if (ModelState.IsValid)
            {
                City newCity = new City()
                {
                    CityName = model.CityName,
                    StateId = (int)model.StateId,
                    
                };
                var city = _cityInterface.AddCity(newCity);
                return RedirectToAction("Index", new { newCity.Id });
            }
            var state = _stateInterface.GetAllState();
            ViewBag.States = new SelectList(state, "Id", "StateName");
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var city = _cityInterface.GetCity(id);
            var state = _stateInterface.GetAllState();

            if (city != null)
            {
                CityDTO model = new CityDTO()
                {
                    CityName = city.CityName,
                    StateId = city.StateId,
                   
                };

                ViewBag.States = new SelectList(state, "Id", "StateName");

                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(CityDTO model)
        {
            if (ModelState.IsValid)
            {
                var city = _cityInterface.GetCity(model.Id);
                if (city != null)
                {
                    city.CityName = model.CityName;
                    city.StateId = (int)model.StateId;


                    _cityInterface.UpdateCity(city);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
           
            var states = _stateInterface.GetAllState();
            ViewBag.states = new SelectList(states, "Id", "StateName");
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var city = _cityInterface.GetCity(id);
            if (city != null)
            {
                _cityInterface.DeleteCity(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
