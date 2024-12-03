using EmployeeManagement.Api.Models;
using EmployeeManagement.Data;
using EmployeeManagement.Services;
using EmployeeManagement.Shared;
using Moq;

public class EmployeeServiceTests
{
    private readonly Mock<IEmployeeRepository> _repositoryMock;
    private readonly EmployeeService _service;

    public EmployeeServiceTests()
    {
        _repositoryMock = new Mock<IEmployeeRepository>();
        _service = new EmployeeService(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetAllEmployeesAsync_ShouldReturnAllEmployees()
    {
        var employees = new List<Employee>
        {
            new(1, "John Doe", "Developer", "IT"),
            new(2, "Jane Smith", "Manager", "HR")
        };
       
      

        _repositoryMock.Setup(repo => repo.GetAllEmployeesAsync()).ReturnsAsync(employees);

        var result = await _service.GetAllEmployeesAsync();

        Assert.Equal(2, result.Count());
    }
}