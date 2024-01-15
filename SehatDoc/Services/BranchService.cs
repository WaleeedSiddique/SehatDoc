using Microsoft.EntityFrameworkCore;
using SehatDoc.BranchInterfaces;
using SehatDoc.DatabaseContext;
using SehatDoc.DoctorModels;
using SehatDoc.Interfaces;
using SehatDoc.Models;
using SehatDoc.ViewModels;

namespace SehatDoc.Services
{
    public class BranchService: IBranchInterface
    {
        private readonly AppDbContext _context;
        public BranchService(AppDbContext context)
        {
            this._context = context;
        }
        public Branch AddBranch(Branch branch)
        {
            var brnch = _context.branches.Add(branch);
            _context.SaveChanges();
            return branch;
        }
        //public IEnumerable<BranchViewModel> GetBranchesForHospital(int? hospitalId)
        //{
        //    var branches = _context.branches
        //        .Where(b => b.HospitalID == hospitalId)
        //        .Select(b => new BranchViewModel
        //        {
        //            BranchID = b.BranchID,
        //           // BranchName = b.BranchName,
        //            HospitalID = b.HospitalID,
        //            Contact1 = b.Contact1,
        //            Contact2 = b.Contact2,
        //            //State = b.State,
        //          //  Location = b.Location,
        //          //  DepartmentIDs = (List<int>)b.DepartmentHospitalProfiles

        //            // Map other properties as needed
        //        })
        //        .ToList();

        //    return branches;
        //}
      
        public void DeleteBranch(int id)
        {
            var branch = _context.branches.FirstOrDefault(x => x.BranchID == id);
            if (branch != null)
            {
                _context.branches.Remove(branch);
                _context.SaveChanges();
            }
        }
        //public IEnumerable<Branch> GetBranchesForHospital(int? hospitalId)
        //{
        //    var branches = _context.branches
        //        .Where(b => b.HospitalID == hospitalId)
        //        .ToList();

        //    return branches;
        //}

    }
}
