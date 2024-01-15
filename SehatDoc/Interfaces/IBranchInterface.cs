﻿using SehatDoc.Models;
using SehatDoc.ViewModels;

namespace SehatDoc.BranchInterfaces
{
    public interface IBranchInterface
    {
        public Branch AddBranch(Branch branch);
        //public IEnumerable<BranchViewModel> GetBranchesForHospital(int? hospitalId);
        public void DeleteBranch(int id);
    }
}
