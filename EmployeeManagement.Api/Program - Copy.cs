/*
Key .NET 9 Improvements:
Endpoint Metadata Enhancements:
.WithName() assigns a specific name to an endpoint, useful for linking or documentation.
.WithTags() groups related endpoints, making API documentation (like Swagger) more organized.
Streamlined Syntax:
Simplified routing and dependency injection in Minimal APIs.
*/


using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Models;
using static EmployeeManagement.Api.Models.EmployeeDTO;





var builder = WebApplication.CreateBuilder(args);

// Register repository with dependency injection
builder.Services.AddSingleton<InMemoryEmployeeRepository>();

// List of employees (used for demonstration purposes)
var employees = new List<Employee>
{
    new Employee { Id = 1, Name = "John Doe", JobTitle = "Developer", Department = "IT" },
    new Employee { Id = 2, Name = "Jane Doe", JobTitle = "Manager", Department = "HR" }
};
var app = builder.Build();


app.MapGet("/api/employees/{id}", (int id) =>
{
    // Example: Fetch employee from database or in-memory list
    var employee = new Employee
    {
        Id = id,
        Name = "John Doe",
        JobTitle = "Developer",
        Department = "IT"
    };

    // Map Employee to EmployeeDto
    var employeeDto = new EmployeeDto(employee.Id, employee.Name);
    return Results.Ok(employeeDto);
});




app.MapGet("/employees", (InMemoryEmployeeRepository repository) =>
    Results.Ok(repository.GetAll()))
    .WithName("GetAllEmployees")  // Name the endpoint
    .WithTags("Employees");       // Group endpoints for better API documentation

app.MapGet("/employees/{id:int}", (int id, InMemoryEmployeeRepository repository) =>
{
    var employee = repository.GetById(id);
    return employee is not null ? Results.Ok(employee) : Results.NotFound();
})
    .WithName("GetEmployeeById")
    .WithTags("Employees");

app.MapPost("/employees", (Employee employee, InMemoryEmployeeRepository repository) =>
{
    repository.Add(employee);
    return Results.Created($"/employees/{employee.Id}", employee);
})
    .WithName("AddEmployee")
    .WithTags("Employees");

app.MapDelete("/employees/{id:int}", (int id, InMemoryEmployeeRepository repository) =>
{
    var success = repository.Delete(id);
    return success ? Results.NoContent() : Results.NotFound();
})
    .WithName("DeleteEmployee")
    .WithTags("Employees");

app.Run();


