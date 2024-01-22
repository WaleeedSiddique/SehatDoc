using SehatDoc.Models;

namespace SehatDoc.Interfaces
{
    public interface ICityInterface
    {
        public IEnumerable<City> GetAllCity();
        public City AddCity(City city);
        public City GetCity(int id);
        public void DeleteCity(int id);
        public City UpdateCity(City city);
    }
}
