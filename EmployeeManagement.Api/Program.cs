using EmployeeManagement.Api.Models;
using EmployeeManagement.Data;
using EmployeeManagement.Services;
using Microsoft.EntityFrameworkCore;

//-----------------------------------------------------------
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("EmployeeDb"));// Using In-Memory database for simplicity
//builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//---------------------------------

//---------------------------------

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(); // Adds Swagger services
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Employee Management API", Version = "v1" });
   

});
// Configure services


//------------------------------------------------------------------------
var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    AppDbContext.SeedDatabase(dbContext);
}
//------------------------------------------------------------------
// Define API endpoints
app.MapGet("/employees", async (IEmployeeService service) =>
{
    var employees = await service.GetAllEmployeesAsync();
    return Results.Ok(employees);
});

app.MapGet("/employees/{id:int}", async (IEmployeeService service, int id) =>
{
    var employee = await service.GetEmployeeByIdAsync(id);
    return employee != null ? Results.Ok(employee) : Results.NotFound();
});

app.MapPost("/employees", async (IEmployeeService service, Employee employee) =>
{
    await service.AddEmployeeAsync(employee);
    return Results.Created($"/employees/{employee.Id}", employee);
});


//------------------------------------------------------------------------------
// Configure middleware and the request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Redirect root URL to Swagger UI
    app.MapGet("/", context =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });
}


//app.MapGet("/", () => "Welcome to Employee Management API");


app.Run();





