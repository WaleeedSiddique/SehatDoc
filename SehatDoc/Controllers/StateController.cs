using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.DTO_s;
using SehatDoc.Interfaces;
using SehatDoc.Models;
using SehatDoc.SymptomsDTO_s;
using SehatDoc.SymptomsInterfaces;

namespace SehatDoc.Controllers
{
    public class StateController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IStateInterface _stateInterface;

        public StateController(AppDbContext context, IStateInterface _state)
        {
            this._context = context;
            this._stateInterface = _state;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var states = _stateInterface.GetAllState();
            return View(states);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StateDTO dto)
        {

            if (ModelState.IsValid)
            {
              
                State state = new State()
                {
                    StateName = dto.StateName,
                   
                };
                var states = _stateInterface.AddState(state);
                return RedirectToAction("Index", new { state.Id });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var state = _stateInterface.GetState(id);

            if (state != null)
            {
                StateDTO model = new StateDTO()
                {
                    Id = state.Id,
                    StateName = state.StateName,
                
                };


                return View(model);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(StateDTO model)
        {
            if (ModelState.IsValid)
            {
                var state = _stateInterface.GetState(model.Id);
                if (state != null)
                {
                    state.StateName = model.StateName;
                 

                    _stateInterface.UpdateState(state);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var state = _stateInterface.GetState(id);
            if (state != null)
            {
                _stateInterface.DeleteState(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult GetCitiesByState(int stateId)
        {
            var cities = _context.cities.Where(c => c.StateId == stateId).ToList();
            return Json(cities);
        }
    }
}
