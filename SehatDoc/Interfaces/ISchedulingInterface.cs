using SehatDoc.Models;

namespace SehatDoc.Interfaces
{
    public interface ISchedulingInterface
    {
        public DoctorHospitalSchedule AddSchedule(DoctorHospitalSchedule schedule);
        public IEnumerable<DoctorHospitalSchedule>GetSchedules();
       
    }
}
