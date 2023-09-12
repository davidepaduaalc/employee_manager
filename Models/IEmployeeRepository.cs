using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;


namespace employee_manager.Models
{
    public interface IEmployeeRepository
    {   
        Employee GetEmployee(int id);

        IEnumerable<Employee> Get_Allemployee();
        
        Employee Add(Employee employee);
        Employee Empty(); 
    }
}