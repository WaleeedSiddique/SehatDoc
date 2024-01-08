using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DiseaseInterfaces;
using SehatDoc.DoctorRepositories;
using SehatDoc.DiseaseRepositories;
using SehatDoc.SymptomsInterfaces;
using SehatDoc.Services;
using SehatDoc.DepartmentInterfaces;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.Interfaces;
using Microsoft.AspNetCore.Identity;
using SehatDoc.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Other configuration options
    // options.SignIn.RequireConfirmedAccount = true;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false; // Only if email confirmation is not required
    options.SignIn.RequireConfirmedPhoneNumber = false; // Only if phone number confirmation is not required
    

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

// Additional Identity configurations can be added here

builder.Services.AddScoped<ISpecialityInterface,SpecialityService>();
builder.Services.AddScoped<IDoctorInteraface,DoctorService>();
builder.Services.AddScoped<IDiseaseInterface, DiseaseService>();
builder.Services.AddScoped<ISymptomsInterface, SymptomsService>();
builder.Services.AddScoped<IDepartmentInterface, DepartmentService>();
builder.Services.AddScoped<IHospitalProfileInterface, HospitalProfileService>();
builder.Services.AddScoped<ISchedulingInterface, ScheduleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Dashboard}/{id?}");

app.Run();
