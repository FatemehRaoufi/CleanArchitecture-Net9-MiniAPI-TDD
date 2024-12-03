namespace EmployeeManagement.Api.Models
{
    // Full model with behavior
    public class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public string JobTitle { get; }
        public string Department { get; }

        // Parameterless constructor for EF Core to work
        public Employee() { }
        public Employee(int id, string name, string jobTitle, string department)
        {
            Id = id;
            Name = name;
            JobTitle = jobTitle;
            Department = department;
        }

       
        // Example: Behavior to calculate salary
        public double CalculateSalary()
        {
            return 1000.0; // Example logic
        }
       
    }
   
   

    }
