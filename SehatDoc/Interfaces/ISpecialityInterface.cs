using SehatDoc.DoctorModels;
using SehatDoc.ViewModels;

namespace SehatDoc.DoctorInterfaces
{
    public interface ISpecialityInterface
    {
        public IEnumerable<Specialities> GetAllSpecialities();
        public int GetTotalDoctorCount();
        public Specialities GetSpecialityById(int id);
        public Specialities AddSpeciality(Specialities speciality);
        public Specialities UpdateSpeciality(int specialityId, Specialities SpecialityChanges, List<int> selectedDiseaseIds);
        public Specialities DeleteSpeciality(Specialities speciality);
        void AddSpecialityWithDiseases(SpecialityWithDiseasesViewModel viewModel);

    }
}
