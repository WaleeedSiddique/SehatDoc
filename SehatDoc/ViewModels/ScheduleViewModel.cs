namespace SehatDoc.ViewModels
{
    public class ScheduleViewModel
    {
        public int DoctorId { get; set; }
        public int HospitalId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
