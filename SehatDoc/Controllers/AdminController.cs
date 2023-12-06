using Microsoft.AspNetCore.Mvc;
using SehatDoc.DepartmentInterfaces;
using SehatDoc.DoctorDTO_s;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.Models;
using SehatDoc.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SehatDoc.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHospitalProfileInterface _hospitalProfileInterface;
        private readonly IDoctorInteraface _doctorInterface;
        private readonly ISpecialityInterface _speciality;
        private readonly IHostingEnvironment _hosting;
        public AdminController(IHospitalProfileInterface hospitalProfileInteraface, ISpecialityInterface speciality, IHostingEnvironment hosting)
        {
            this._hospitalProfileInterface = hospitalProfileInteraface;
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

                // Assuming DoctorHospitalProfiles has a property Doctor
                 var doctors = doctorHospitalProfiles?.Select(dhp => dhp.Doctor).ToList();
             
                var dashboardViewModel = new DashboardViewModel
                {
                    DoctorHospitalProfiles = doctorHospitalProfiles?.ToList(),
                    doctors = doctors,
                    TotalDoctorCount = totalDoctorCount,
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

        //[HttpGet]
        //public IActionResult Dashboard()
        //{
        //    try
        //    {
        //        var doctorHospitalProfiles = _hospitalProfileInterface.GetAllHospitalProfileForDashboard();
        //        var totalDoctorCount = _speciality.GetTotalDoctorCount();

        //        // Assuming DoctorHospitalProfiles has a property Doctor
        //        var doctors = doctorHospitalProfiles?.Select(dhp => dhp.Doctor).ToList();

        //        var dashboardViewModel = new DashboardViewModel
        //        {
        //            DoctorHospitalProfiles = doctorHospitalProfiles?.ToList(),
        //            doctors = doctors,
        //            TotalDoctorCount = totalDoctorCount,
        //        };

        //        return View(dashboardViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception for further investigation
        //        Console.WriteLine($"Exception in Dashboard action: {ex}");
        //        throw; // Rethrow the exception to see the detailed error in the browser
        //    }
        //}


        //[HttpGet]
        //public IActionResult Dashboard()
        //{
        //    try
        //    {
        //        var doctorHospitalProfiles = _hospitalProfileInterface.GetAllHospitalProfileForDashboard();
        //        var totalDoctorCount = _speciality.GetTotalDoctorCount();

        //        var dashboardViewModel = new DashboardViewModel
        //        {
        //            DoctorHospitalProfiles = doctorHospitalProfiles?.ToList(),
        //            TotalDoctorCount = totalDoctorCount,
        //        };

        //        return View(dashboardViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception for further investigation
        //        Console.WriteLine($"Exception in Dashboard action: {ex}");
        //        throw; // Rethrow the exception to see the detailed error in the browser
        //    }
        //}






    }
}
