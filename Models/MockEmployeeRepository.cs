using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Hosting;


namespace employee_manager.Models
{       
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>(){
            new Employee() {Id = 1, Name = "jp", Department = Dept.HR, Email = "jp@gmail.com"},
            new Employee() {Id = 2, Name = "rr", Department = Dept.HR, Email = "rr@gmail.com"},
            new Employee() {Id = 3, Name = "lui", Department = Dept.HR, Email = "lui@gmail.com"}
            };
        }
        public Employee GetEmployee(int Id){
            return _employeeList.FirstOrDefault(e => e.Id == Id) ?? Empty();
        }

        public Employee Empty(){
            return new Employee(){
                Id = 0,
                Name = string.Empty,
                Department = Dept.None,
                Email = string.Empty
            };
        }
        
        public IEnumerable<Employee> Get_Allemployee(){
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }
    }
}