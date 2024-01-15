using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class DepartmentHospitalProfile
    {
        [Key]
        public int Id { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department DepartmentsDepartment { get; set; }
        public int HospitalID { get; set; }
       public virtual HospitalProfile HospitalProfilesHospital { get; set; }
        public int ?BranchID { get; set; }
     public virtual Branch HospitalBranch { get; set; }
    }
}
