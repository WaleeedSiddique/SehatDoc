using SehatDoc.Models;

namespace SehatDoc.DTO_s
{
    public class DepartmentHospitalProfileDTO
    {
        public int ID { get; set; }
        public int DepartmentsDepartmentID { get; set; }
        public int HospitalProfilesHospitalID { get; set; }

        public virtual Department DepartmentsDepartment { get; set; }
        public virtual HospitalProfile HospitalProfilesHospital { get; set; }
    }
}
