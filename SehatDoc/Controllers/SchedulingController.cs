using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorModels;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.Interfaces;
using SehatDoc.Models;
using SehatDoc.ViewModels;

namespace SehatDoc.Controllers
{
    public class SchedulingController : Controller
    {
        private readonly ISchedulingInterface _schedule;
        private readonly AppDbContext _context;
       

        public SchedulingController(ISchedulingInterface schedule,AppDbContext context)
        {
            this._schedule = schedule;
            this._context = context;
        }
        [HttpGet]
        public IActionResult AddSchedule(int id)
        {
            var model = new DoctorHospitalSchedule { doctorId = id };
            ViewBag.hospitals = new SelectList(_context.HospitalProfiles.ToList(), "HospitalID", "HospitalName");
            return View(model);
        }
        [HttpPost]
        public IActionResult AddSchedule(DoctorHospitalSchedule model)
        {
            if (ModelState.IsValid)
            {
                var newSchedule = new DoctorHospitalSchedule
                {
                    doctorId = model.doctorId,
                    HospitalId = model.HospitalId,
                    DayOfWeek = model.DayOfWeek,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                };

                _schedule.AddSchedule(newSchedule);
                _context.SaveChanges();
                return RedirectToAction("GetSchedule","Doctor");
            }
            return View(model);
        }
    }
}
