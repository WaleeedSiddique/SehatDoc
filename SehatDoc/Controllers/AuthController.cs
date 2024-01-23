using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.Models;
using SehatDoc.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SehatDoc.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment _hosting;
        private readonly ISpecialityInterface _speciality;
        private readonly IHospitalProfileInterface _hospital;
        private readonly AppDbContext _context;

        public AuthController
          (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHostingEnvironment hosting, ISpecialityInterface speciality, IHospitalProfileInterface hospital, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._hosting = hosting;
            this._speciality = speciality;
            this._hospital = hospital;
            this._context = context;

        }
        public IActionResult Index(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                ViewBag.Username = username;
                return View();
            }
            else
            {
                // Handle the case when the username is not provided
                return RedirectToAction("SignUp"); // Redirect to login or handle as needed
            }
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            var speclities = _speciality.GetAllSpecialities();
            var hospitals = _hospital.GetAllHospitalProfile();
            ViewBag.Specialities = new SelectList(speclities, "Id", "SpecialityName");
            ViewBag.HospitalProfile = new SelectList(hospitals, "HospitalID", "HospitalName");
            var states = _context.states.ToList();
            ViewBag.states = new SelectList(states, "Id", "StateName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(ApplicationUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new ApplicationUser
                    {
                        Name = model.Name,
                        Qualification = model.Qualification,
                        Email = model.Email,
                      //  PasswordHash = model.Password,
                        PhoneNumber = model.PhoneNumber,
                        StateId = model.StateId,
                        CityId = model.CityId,
                        HospitalID = model.HospitalID,
                        specialityId = model.specialityId,

                        UserName = model.Name
                    };

                    var result = await _userManager.CreateAsync(user,model.Password);

                    if (result.Succeeded)
                    {
                       // var doctor = new Doctor()
                       // {
                       //     LastName =model.Name;

                       // };
                       //_context.Doctors.Add(doctor);
                       // _context.SaveChanges();


                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("SignIn", new { username = user.UserName });
                    }
                    else
                    {

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred during user registration.");
                }
            }

            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find user by username (you can also use email or phone number)
                  var user = await _userManager.FindByNameAsync(model.Name);

                // if (user != null)
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        // Successful sign-in
                        return RedirectToAction("Index", "Auth", new { username = user.UserName });
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found");
                    return View(model);
                }
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            // Redirect to the home page or any other desired page after sign-out
            return RedirectToAction("Index", "Home");

        }
    }
}
