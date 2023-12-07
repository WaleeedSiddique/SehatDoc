using SehatDoc.DoctorModels;

namespace SehatDoc.Models
{
    public class DoctorHospitalSchedule
    {
        public int id {  get; set; }
        public int HospitalId { get; set; }
        public HospitalProfile? Hospitals { get; set; }
        public int doctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }



    }
}
