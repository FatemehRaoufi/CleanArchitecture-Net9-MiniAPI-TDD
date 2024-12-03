

using EmployeeManagement.Api.Models;
using System.Xml.Linq;

namespace EmployeeManagement.Api.Data
{
    
    public class InMemoryEmployeeRepository
    {
        private readonly List<Employee> _employees = new()
    {
        new Employee(1, "Alice"),
        new Employee(2, "Bob")
    };

        public IEnumerable<Employee> GetAll() => _employees;

        public Employee? GetById(int id) =>
            _employees.FirstOrDefault(e => e.Id == id);

        public void Add(Employee employee) =>
            _employees.Add(employee);

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null) return false;
            _employees.Remove(employee);
            return true;
        }
    }

}
