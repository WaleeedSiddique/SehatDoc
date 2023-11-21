
using SehatDoc.Models;

namespace SehatDoc.DiseaseInterfaces
{
    public interface IDiseaseInterface
    {
        public IEnumerable<Disease> GetAllDisease();
        public Disease GetDisease(int id);
        public Disease UpdateDisease(Disease disease);
        public void DeleteDisease(int id);
        public Disease AddDisease (Disease disease);
    }
}
