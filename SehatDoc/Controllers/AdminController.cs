using Microsoft.AspNetCore.Mvc;
using SehatDoc.DoctorDTO_s;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SehatDoc.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDoctorInteraface _doctorInterface;
        private readonly IHostingEnvironment _hosting;
        private readonly ISpecialityInterface _speciality;
        private readonly IHospitalProfileInterface _hospitalProfileInterface;

        public AdminController
            (IDoctorInteraface doctorInteraface, IHostingEnvironment hosting, ISpecialityInterface speciality, IHospitalProfileInterface hospitalprofile)
        {
            this._doctorInterface = doctorInteraface;
            this._hosting = hosting;
            this._speciality = speciality;
            this._hospitalProfileInterface = hospitalprofile;
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
