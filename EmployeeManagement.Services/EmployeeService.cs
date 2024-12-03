using EmployeeManagement.Api.Models;
using EmployeeManagement.Data;
using EmployeeManagement.Shared;

namespace EmployeeManagement.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() => await _repository.GetAllEmployeesAsync();

    public async Task<Employee?> GetEmployeeByIdAsync(int id) => await _repository.GetEmployeeByIdAsync(id);

    public async Task AddEmployeeAsync(Employee employee) => await _repository.AddEmployeeAsync(employee);
}
