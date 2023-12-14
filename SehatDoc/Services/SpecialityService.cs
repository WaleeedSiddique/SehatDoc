using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorInterfaces;
using SehatDoc.DoctorModels;
using SehatDoc.Models;
using SehatDoc.ViewModels;

namespace SehatDoc.DoctorRepositories
{
    public class SpecialityService : ISpecialityInterface
    {
        private readonly AppDbContext _context;

        public SpecialityService(AppDbContext context)
        {
            this._context = context;
        }
        public Specialities AddSpeciality(Specialities speciality)
        {
            var model = _context.Specialities.Add(speciality);
            _context.SaveChanges();
            return speciality;
        } 

        public Specialities DeleteSpeciality(Specialities speciality)
        {
            var model = _context.Specialities.FirstOrDefault(x => x.Id == speciality.Id);
            if(model != null)
            {
                _context.Specialities.Remove(model);
                _context.SaveChanges();
            }
            return speciality;
        }

        public IEnumerable<Specialities> GetAllSpecialities()
        {
            var specialities = _context.Specialities.Include(x => x.doctors).Include(s => s.SpecialtyDiseases).ThenInclude(sd => sd.Disease).ToList();
            return specialities;
        }

        public Specialities GetSpecialityById(int id)
        {
            return _context.Specialities
             .Include(s => s.SpecialtyDiseases)
                 .ThenInclude(sd => sd.Disease)
             .Include(s => s.doctors)
             .FirstOrDefault(s => s.Id == id);
        }
        public Specialities UpdateSpeciality(int specialityId, Specialities specialityChanges, List<int> selectedDiseaseIds)
        {
            var existingSpeciality = _context.Specialities
                .Include(s => s.SpecialtyDiseases)
                .SingleOrDefault(s => s.Id == specialityId);

            if (existingSpeciality != null)
            {
                existingSpeciality.SpecialityName = specialityChanges.SpecialityName;

                // Update associated diseases
                existingSpeciality.SpecialtyDiseases.Clear();
                foreach (var diseaseId in selectedDiseaseIds)
                {
                    existingSpeciality.SpecialtyDiseases.Add(new SpecialtyDisease { DiseaseId = diseaseId });
                }

                _context.SaveChanges();
                return existingSpeciality;
            }

            return null; // or throw an exception if necessary
        }



        //public Specialities UpdateSpeciality(Specialities SpecialityChanges)
        //{
        //    var speciality = _context.Specialities.Attach(SpecialityChanges);
        //    speciality.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    _context.SaveChanges();
        //    return SpecialityChanges;
        //}

        public void AddSpecialityWithDiseases(SpecialityWithDiseasesViewModel viewModel)
        {
            var speciality = new Specialities
            {
                SpecialityName = viewModel.SpecialityName,            
            };

            var selectedDiseases = _context.Diseases
                .Where(d => viewModel.SelectedDiseaseIds.Contains(d.DiseaseID))
                .ToList();

            speciality.SpecialtyDiseases = selectedDiseases.Select(disease => new SpecialtyDisease
            {
                Specialty = speciality,
                Disease = disease
            }).ToList();

            _context.Specialities.Add(speciality);
            _context.SaveChanges();
        }
        public int GetTotalDoctorCount()
        {
            return _context.Doctors.Count();
        }
    }

}
