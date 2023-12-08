using Microsoft.AspNetCore.Mvc;
using SehatDoc.DepartmentInterfaces;
using SehatDoc.DoctorDTO_s;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.Models;
using SehatDoc.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.EntityFrameworkCore;


namespace SehatDoc.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHospitalProfileInterface _hospitalProfileInterface;
        private readonly IDoctorInteraface _doctorInterface;
        private readonly ISpecialityInterface _speciality;
        private readonly IHostingEnvironment _hosting;
        public AdminController(IHospitalProfileInterface hospitalProfileInteraface, IDoctorInteraface doctor,ISpecialityInterface speciality, IHostingEnvironment hosting)
        {
            this._hospitalProfileInterface = hospitalProfileInteraface;
            this._doctorInterface = doctor;
            this._speciality = speciality;
            this._hosting = hosting;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            try
            {
                var doctorHospitalProfiles = _hospitalProfileInterface.GetAllHospitalProfileForDashboard();
                var totalDoctorCount = _speciality.GetTotalDoctorCount();
                var doctors = _doctorInterface.GetAllDoctors();
                var totalHospitalCount = _hospitalProfileInterface.GetTotalHospitalCount(); // New line
               

                var dashboardViewModel = new DashboardViewModel
                {
                    DoctorHospitalProfiles = doctorHospitalProfiles?.ToList(),
                    doctors = (ICollection<Doctor>)doctors,
                    TotalDoctorCount = totalDoctorCount,
                    //TotalHospitalCount = totalHospitalCount
                    Hospitals = totalHospitalCount?.ToList(),
                };


                return View(dashboardViewModel);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                Console.WriteLine($"Exception in Dashboard action: {ex}");
                throw; // Rethrow the exception to see the detailed error in the browser
            }
        }

    }
}
