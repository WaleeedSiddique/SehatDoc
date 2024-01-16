using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.Interfaces;
using SehatDoc.Models;

namespace SehatDoc.Services
{
    public class ScheduleService : ISchedulingInterface
    {
        private readonly AppDbContext _context;

        public ScheduleService(AppDbContext context)
        {
            this._context = context;
        }
        public DoctorHospitalSchedule AddSchedule(DoctorHospitalSchedule schedule)
        {
              _context.schedules.Add(schedule);
            _context.SaveChanges();
            return schedule;
        }
        public bool IsAlreadyScheduled(int doctorId, TimeSpan startTime, TimeSpan endTime, DayOfWeek dayOfWeek)
        {
            DateTime today = DateTime.Today;

            TimeSpan startDateTime = today.Add(startTime).TimeOfDay;
            TimeSpan endDateTime = today.Add(endTime).TimeOfDay;

            return _context.schedules.Any(s =>
                s.doctorId == doctorId &&
                s.DayOfWeek == dayOfWeek &&
                (
                    // Check if the new schedule's start time is within the existing schedule
                    (startDateTime >= s.StartTime && startDateTime < s.EndTime) ||

                    // Check if the new schedule's end time is within the existing schedule
                    (endDateTime > s.StartTime && endDateTime <= s.EndTime) ||

                    // Check if the new schedule completely overlaps with the existing schedule
                    (startDateTime <= s.StartTime && endDateTime >= s.EndTime)
                )
            );
        }



        public IEnumerable<DoctorHospitalSchedule> GetSchedules()
        {
            throw new NotImplementedException();
        }
    }
}
