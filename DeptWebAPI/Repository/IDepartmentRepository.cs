
namespace DeptWebAPI.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartment();
        Task<Department> GetDepartmentByID(int id);
        Task<Department> InsertDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        bool DeleteDepartment(string id);
        Task<Department> GetDepartmentByName(string name);

    }
}
