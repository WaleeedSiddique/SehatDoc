using SehatDoc.DoctorModels;
using SehatDoc.Models;

namespace SehatDoc.HospitalProfileInterfaces
{
    public interface IHospitalProfileInterface
    {
        public IEnumerable<HospitalProfile> GetAllHospitalProfile();
        public IEnumerable<DoctorHospitalProfile> GetAllHospitalProfileForDashboard();
        public HospitalProfile GetHospitalProfile(int id);
        public HospitalProfile UpdateHospitalProfile(HospitalProfile hospitalProfile);
        public void DeleteHospitalProfile(int id);
        public HospitalProfile AddHospitalProfile(HospitalProfile hospitalProfile);
        public IEnumerable<HospitalProfile> GetTotalHospitalCount();
    }
}
