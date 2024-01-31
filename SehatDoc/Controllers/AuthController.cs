using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorDTO_s;
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
            return View();
        }
        public async Task<IActionResult> SignUp(ApplicationUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var existingDoctor = _context.Doctors.FirstOrDefault(d => d.Email == model.Email);

                        var user = new ApplicationUser
                        {
                            Name = model.Name,
                            Email = model.Email,
                            PasswordHash = model.Password,
                            PhoneNumber = model.PhoneNumber,
                            UserName = model.Name
                        };

                        var result = await _userManager.CreateAsync(user, model.Password);

                        if (result.Succeeded)
                        {
                            if (existingDoctor != null)
                            {
                                existingDoctor.ApplicationUserId = user.Id;
                                _context.SaveChanges();
                            }
                            else
                            {
                                var doctor = new Doctor()
                                {
                                    LastName = model.Name,
                                    FirstName = model.Name,
                                    Email = model.Email,
                                    ApplicationUserId = user.Id,
                                };

                                _context.Doctors.Add(doctor);
                                _context.SaveChanges();
                            }

                            await _signInManager.SignInAsync(user, isPersistent: false);

                            transaction.Commit(); 

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
                        transaction.Rollback();
                        ModelState.AddModelError(string.Empty, "An error occurred during user registration.");
                    }
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
