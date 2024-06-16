namespace DeptWebAPI.Repository
{
    public interface IEmployeeRepository
    {
       Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> GetEmployeeByName(string name);

        Task<Employee> InsertEmployee(Employee employee);

        Task<Employee> UpdateEmployee(Employee employee);

        bool DeleteEmployee(int id);

    }
}
