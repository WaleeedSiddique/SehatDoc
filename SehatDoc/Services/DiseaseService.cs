using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.Models;
using SehatDoc.DiseaseInterfaces;
using SehatDoc.DoctorModels;

namespace SehatDoc.DiseaseRepositories
{
    public class DiseaseService : IDiseaseInterface
    {
        private readonly AppDbContext _context;

        public DiseaseService(AppDbContext context)
        {
            this._context = context;
        }
        public Disease AddDisease(Disease disease)
        {
            var doc = _context.Diseases.Add(disease);
            _context.SaveChanges();
            return disease;
        }
       
        public void DeleteDisease(int id)
        {
            var doc = _context.Diseases.FirstOrDefault(x => x.DiseaseID == id);
            if(doc != null)
            {
                _context.Diseases.Remove(doc);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Disease> GetAllDisease()
        {
            var disease = _context.Diseases.Include(x => x.DiseaseSymptoms).ThenInclude(dh => dh.Symptoms).ToList();
               return disease;
        }
        public Disease GetDisease(int id)
        {
            var disease = _context.Diseases.FirstOrDefault(x => x.DiseaseID == id);

            return disease;
        }

        public Disease UpdateDisease(Disease disease)
        {
            var doc = _context.Diseases.Attach(disease);
            doc.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return disease;
        }
        public IEnumerable<Symptoms> GetAllSymptoms()
        {
            var symptom = _context.Symptoms.ToList();

            return symptom;
        }
        public Disease GetDiseaseByID(int id)
        {
            return _context.Diseases
             .Include(s => s.DiseaseSymptoms)
                 .ThenInclude(sd => sd.Symptoms)
             ///.Include(s => s.doctors)
             .FirstOrDefault(s => s.DiseaseID == id);
        }

        public Disease GetDiseaseWithSymtoms(int id)
        {
            var disease = _context.Diseases
        .Include(d => d.DiseaseSymptoms)
            .ThenInclude(ds => ds.Symptoms)
        .FirstOrDefault(d => d.DiseaseID == id);
            return disease;
        }
    }
}
