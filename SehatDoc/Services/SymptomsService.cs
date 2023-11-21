using SehatDoc.DatabaseContext;
using SehatDoc.Models;
using SehatDoc.SymptomsInterfaces;

namespace SehatDoc.Services
{
    public class SymptomsService : ISymptomsInterface
    {
        private readonly AppDbContext _context;

        public SymptomsService(AppDbContext context)
        {
            this._context = context;
        }
        public Symptoms AddSymptoms(Symptoms symptoms)
        {
            var symptom = _context.Symptoms.Add(symptoms);
            _context.SaveChanges();
            return symptoms;
        }
        public IEnumerable<Symptoms> GetAllSymptoms()
        {
            var symptom = _context.Symptoms.ToList();

            return symptom;
        }
        public void DeleteSymptoms(int id)
        {
            var symptom = _context.Symptoms.FirstOrDefault(x => x.SymptomID == id);
            if (symptom != null)
            {
                _context.Symptoms.Remove(symptom);
                _context.SaveChanges();
            }
        }
        public Symptoms GetSymptom(int id)
        {
            var symptom = _context.Symptoms.FirstOrDefault(x => x.SymptomID == id);

            return symptom;
        }

        public Symptoms UpdateSymptom(Symptoms symptom)
        {
            var sym = _context.Symptoms.Attach(symptom);
            sym.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return symptom;
        }
    }
}
