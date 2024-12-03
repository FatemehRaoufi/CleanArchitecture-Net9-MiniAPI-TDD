using EmployeeManagement.Api.Models;
using EmployeeManagement.Shared;

namespace EmployeeManagement.Data;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(Employee employee);
}
