using EmployeeManagement.Api.Models;
using EmployeeManagement.Shared;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() => await _context.Employees.ToListAsync();

    public async Task<Employee?> GetEmployeeByIdAsync(int id) => await _context.Employees.FindAsync(id);

    public async Task AddEmployeeAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }
}
