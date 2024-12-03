using EmployeeManagement.Api.Models;
using EmployeeManagement.Shared;

namespace EmployeeManagement.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(Employee employee);
}
