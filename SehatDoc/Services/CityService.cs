using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorEnums;
using SehatDoc.Interfaces;
using SehatDoc.Models;

namespace SehatDoc.Services
{
    public class CityService: ICityInterface
    {
        private readonly AppDbContext _context;
        public CityService(AppDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<City> GetAllCity()
        {
            var city = _context.cities.Include(st => st.State).ToList();
            return city;
        }
        public City AddCity(City city)
        {
            var citi = _context.cities.Add(city);
            _context.SaveChanges();
            return city;
        }
        public City GetCity(int id)
        {
            var citi = _context.cities.FirstOrDefault(x => x.Id == id);
            return citi;
        }
        public City UpdateCity(City city)
        {
            var cities = _context.cities.Attach(city);
            cities.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return city;
        }
        public void DeleteCity(int id)
        {
            var citi = _context.cities.FirstOrDefault(x => x.Id == id);
            if (citi != null)
            {
                _context.cities.Remove(citi);
                _context.SaveChanges();
            }
        }
    }
}
