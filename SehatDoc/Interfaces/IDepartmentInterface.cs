using SehatDoc.Models;

namespace SehatDoc.DepartmentInterfaces
{
    public interface IDepartmentInterface
    {
        public IEnumerable<Department> GetAllDepartment();
        public Department GetDepartment(int id);
        public Department UpdateDepartment(Department department);
        public void DeleteDepartment(int id);
        public Department AddDepartment(Department department);
    }
}
