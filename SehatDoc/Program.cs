using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DiseaseInterfaces;
using SehatDoc.DoctorRepositories;
using SehatDoc.DiseaseRepositories;
using SehatDoc.SymptomsInterfaces;
using SehatDoc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ISpecialityInterface,SpecialityService>();
builder.Services.AddScoped<IDoctorInteraface,DoctorService>();
builder.Services.AddScoped<IDiseaseInterface, DiseaseService>();
builder.Services.AddScoped<ISymptomsInterface, SymptomsService>();

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
    pattern: "{controller=Doctor}/{action=ListDoctors}/{id?}");

app.Run();
