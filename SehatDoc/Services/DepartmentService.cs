using SehatDoc.DatabaseContext;
using SehatDoc.DepartmentInterfaces;
using SehatDoc.Models;

namespace SehatDoc.Services
{
    public class DepartmentService : IDepartmentInterface
    {
        private readonly AppDbContext _context;
        public DepartmentService(AppDbContext context)
        {
            this._context = context;
        }
        public Department AddDepartment(Department department)
        {
            var dep = _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public void DeleteDepartment(int id)
        {
            var dep = _context.Departments.FirstOrDefault(x => x.DepartmentID == id);
            if (dep != null)
            {
                _context.Departments.Remove(dep);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Department> GetAllDepartment()
        {
            var dep = _context.Departments.ToList();

            return dep;
        }

        public Department GetDepartment(int id)
        {
            var dep = _context.Departments.FirstOrDefault(x => x.DepartmentID == id);

            return dep;
        }

        public Department UpdateDepartment(Department department)
        {
            var dep = _context.Departments.Attach(department);
            dep.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return department;
        }

    }
}
