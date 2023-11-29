﻿using Microsoft.EntityFrameworkCore;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorModels;
using SehatDoc.HospitalProfileInterfaces;
using SehatDoc.Models;

namespace SehatDoc.Services
{
    public class HospitalProfileService : IHospitalProfileInterface
    {
        private readonly AppDbContext _context;

        public HospitalProfileService(AppDbContext context)
        {
            this._context = context;
        }
        public HospitalProfile AddHospitalProfile(HospitalProfile hospitalProfile)
        {
            var hospital = _context.HospitalProfiles.Add(hospitalProfile);
            _context.SaveChanges();
            return hospitalProfile;
        }

        public void DeleteHospitalProfile(int id)
        {
            var hospital = _context.HospitalProfiles.FirstOrDefault(x => x.HospitalID == id);
            if (hospital != null)
            {
                _context.HospitalProfiles.Remove(hospital);
                _context.SaveChanges();
            }
        }
        public IEnumerable<HospitalProfile> GetAllHospitalProfile()
        {
            var hospitals = _context.HospitalProfiles
                .Include(x => x.DepartmentHospitalProfiles)
                .ThenInclude(dh => dh.DepartmentsDepartment)
                .ToList();

            return hospitals;
        }
        public HospitalProfile GetHospitalProfile(int id)
        {
            var hospital = _context.HospitalProfiles
                .Include(x => x.DepartmentHospitalProfiles)
                    .ThenInclude(dhp => dhp.DepartmentsDepartment)

                .FirstOrDefault(x => x.HospitalID == id);

            return hospital;
        }
        //public IEnumerable<HospitalProfile> GetAllHospitalForDoctor()
        //{
        //    var hospitals = _context.DoctorHospitalProfile
        //        .Where(dh => dh.HospitalID != null)
        //        .Select(dh => dh.HospitalProfile)
        //        .Distinct()
        //        .ToList();

        //    return hospitals;
        //}

      
        public HospitalProfile UpdateHospitalProfile(HospitalProfile hospitalProfile)
        {
            var hospital = _context.HospitalProfiles.Attach(hospitalProfile);
            hospital.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return hospitalProfile;
        }
    }
}
