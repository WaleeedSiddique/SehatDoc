
using SehatDoc.DoctorModels;
using SehatDoc.Models;

namespace SehatDoc.DiseaseInterfaces
{
    public interface IDiseaseInterface
    {
        public IEnumerable<Symptoms> GetAllSymptoms();
        public IEnumerable<Disease> GetAllDisease();
        public Disease GetDisease(int id);
        public Disease UpdateDisease(Disease disease);
        public void DeleteDisease(int id);
        public Disease AddDisease (Disease disease);
        public Disease GetDiseaseByID(int id);
        public Disease GetDiseaseWithSymtoms(int id);
    }
}
