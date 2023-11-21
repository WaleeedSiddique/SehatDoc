using SehatDoc.Models;

namespace SehatDoc.SymptomsInterfaces
{
    public interface ISymptomsInterface
    {
        public IEnumerable<Symptoms> GetAllSymptoms();
        public Symptoms GetSymptom(int id);
        public Symptoms UpdateSymptom(Symptoms symptoms);
        public void DeleteSymptoms(int id);
        public Symptoms AddSymptoms(Symptoms symptoms);
    }
}
