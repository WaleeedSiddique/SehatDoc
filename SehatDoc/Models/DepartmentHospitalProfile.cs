using System.ComponentModel.DataAnnotations;

namespace SehatDoc.Models
{
    public class DepartmentHospitalProfile
    {
        [Key]
        public int Id { get; set; }
        public int DepartmentsDepartmentID { get; set; }
        public int HospitalProfilesHospitalID { get; set; }

        public virtual Department DepartmentsDepartment { get; set; }
        public virtual HospitalProfile HospitalProfilesHospital { get; set; }
    }
}
