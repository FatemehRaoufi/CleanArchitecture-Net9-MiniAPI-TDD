
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Data;

public class AppDbContext : DbContext
{
    // Constructor to pass options to the base class
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }

    public static void SeedDatabase(AppDbContext context)
    {
        if (!context.Employees.Any())
        {
            context.Employees.AddRange(
                new Employee(1, "John Doe", "Developer", "IT"),
                new Employee(2, "Jane Smith", "Manager", "HR")
            );
            context.SaveChanges();
        }
    }
    // Override OnModelCreating to configure the Employee entity
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Always call the base method first

        // Configure the Employee entity
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.Id);  // Set Id as the primary key

        modelBuilder.Entity<Employee>()
            .Property(e => e.Name)
            .HasMaxLength(100); // Set maximum length for the Name property

        modelBuilder.Entity<Employee>()
           .Property(e => e.JobTitle)
           .HasMaxLength(100); // Set maximum length for the JobTitle property

        modelBuilder.Entity<Employee>()
           .Property(e => e.JobTitle)
           .HasMaxLength(100); // Set maximum length for the JobTitle property

        modelBuilder.Entity<Employee>()
          .Property(e => e.Department)
          .HasMaxLength(100); // Set maximum length for the Department property


        // Optionally, seed data for testing or initial setup
        modelBuilder.Entity<Employee>()
            .HasData(
                new Employee(1, "John Doe", "Developer", "IT"),
                new Employee(2, "Jane Smith", "Manager", "HR")
            );
    }

    

}

