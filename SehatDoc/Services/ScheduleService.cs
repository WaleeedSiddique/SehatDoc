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

        public IEnumerable<DoctorHospitalSchedule> GetSchedules()
        {
            throw new NotImplementedException();
        }
    }
}
