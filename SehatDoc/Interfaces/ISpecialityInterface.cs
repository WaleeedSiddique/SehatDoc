using SehatDoc.DoctorModels;
using SehatDoc.ViewModels;

namespace SehatDoc.DoctorInterfaces
{
    public interface ISpecialityInterface
    {
        public IEnumerable<Specialities> GetAllSpecialities();
        public Specialities GetSpecialityById(int id);

        public Specialities AddSpeciality(Specialities speciality);
        public Specialities UpdateSpeciality(Specialities SpecialityChanges);
        public Specialities DeleteSpeciality(Specialities speciality);
        void AddSpecialityWithDiseases(SpecialityWithDiseasesViewModel viewModel);
        public int GetTotalDoctorCount();

    }
}
