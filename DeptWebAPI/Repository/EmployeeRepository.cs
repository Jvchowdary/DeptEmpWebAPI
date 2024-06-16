using Microsoft.EntityFrameworkCore;

namespace DeptWebAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly APIDbContext _context;
        public EmployeeRepository(APIDbContext context)
        {
            _context = context;

        }
        public bool DeleteEmployee(int id)
        {
            bool result = false;
            var emp = _context.Employees.Find(id);

            if (emp != null)
            {
                _context.Entry(emp).State = EntityState.Deleted;
                _context.SaveChanges();
                result = true;
            }
            return result;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> GetEmployeeByName(string name)
        {
            return await _context.Employees.FindAsync(name);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> InsertEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
