using SehatDoc.BranchInterfaces;
using SehatDoc.DatabaseContext;
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
        public IEnumerable<BranchViewModel> GetBranchesForHospital(int? hospitalId)
        {
            var branches = _context.branches
                .Where(b => b.hospitalid == hospitalId)
                .Select(b => new BranchViewModel
                {
                    ID = b.BranchID,
                    BranchName = b.BranchName,
                    HospitalID = b.hospitalid,
                    Contact1 = b.Contact1,
                    Contact2 = b.Contact2,
                    StateId = b.StateId,
                    CityId = b.CityId,
                     Location = b.Location,
                    //  DepartmentIDs = (List<int>)b.DepartmentHospitalProfiles

                    // Map other properties as needed
                })
                .ToList();

            return branches;
        }
        public Branch GetBranch(int id)
        {
            var branch = _context.branches
            .FirstOrDefault(x => x.BranchID == id);
            return branch;

        }
        public Branch UpdateBranch(Branch branch)
        {
            var brnch = _context.branches.Attach(branch);
            brnch.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return branch;
        }
        public void DeleteBranch(int id)
        {
            var branch = _context.branches.FirstOrDefault(x => x.BranchID == id);
            if (branch != null)
            {
                _context.branches.Remove(branch);
                _context.SaveChanges();
            }
        }
        

    }
}
