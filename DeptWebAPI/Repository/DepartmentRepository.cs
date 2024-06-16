using Microsoft.EntityFrameworkCore;

namespace DeptWebAPI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly APIDbContext _context;

        public DepartmentRepository(APIDbContext aPIDbContext)
        {
            _context = aPIDbContext?? throw new ArgumentNullException(nameof(aPIDbContext));
        }

        public bool DeleteDepartment(string id)
        {
            bool result = false;
            var dept=_context.Departments.Find(id);
            if(dept != null)
            {
                _context.Entry(dept).State = EntityState.Deleted;
                _context.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentByID(int id)
        {
           return await _context.Departments.FindAsync(id);
        }

        public async Task<Department> GetDepartmentByName(string name)
        {
          return await _context.Departments.FindAsync(name);
        }

        public async Task<Department> InsertDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }
        public async Task<Department> UpdateDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
