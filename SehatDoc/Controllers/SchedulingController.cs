using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorInterfaces;
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
        private readonly IDoctorInteraface _doctor;

        public SchedulingController(ISchedulingInterface schedule,AppDbContext context,IDoctorInteraface doctor)
        {
            this._schedule = schedule;
            this._context = context;
            this._doctor = doctor;
        }
        [HttpGet]
        public IActionResult AddSchedule(int id)
        {
            var doctor = _doctor.GetDoctor(id);
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
                return RedirectToAction("Index", "Doctor");
            }
            return View(model);
        }
    }
}
