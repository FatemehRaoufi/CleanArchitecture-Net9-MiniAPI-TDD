using EmployeeManagement.Api.Models;
using EmployeeManagement.Data;
using EmployeeManagement.Shared;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepositoryTests
{
    private readonly AppDbContext _context;
    private readonly EmployeeRepository _repository;

    public EmployeeRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _repository = new EmployeeRepository(_context);
    }

    [Fact]
    public async Task AddEmployee_ShouldAddEmployeeSuccessfully()
    {
        // Arrange
        var employee = new Employee(1, "Jane Smith", "Manager", "HR");

        // Act
        await _repository.AddEmployeeAsync(employee);
        var result = await _repository.GetEmployeeByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Jane Smith", result.Name);
    }
    [Fact]
    public async Task GetAllEmployees_ShouldReturnAllEmployees()
    {
        // Arrange
        _context.Employees.AddRange(
            new Employee(1, "John Doe", "Developer", "IT"),
            new Employee(2, "Jane Smith", "Manager", "HR")
        );
        await _context.SaveChangesAsync();

        // Act
        var employees = await _repository.GetAllEmployeesAsync();

        // Assert
        Assert.NotNull(employees);
        Assert.Equal(2, employees.Count());
    }

    [Fact]
    public async Task GetEmployeeById_ShouldReturnEmployee_WhenEmployeeExists()
    {
        // Arrange
        var employee = new Employee(1, "John Doe", "Developer", "IT");
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetEmployeeByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John Doe", result.Name);
    }
}

