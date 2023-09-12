using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace employee_manager.Models
{
    public class Employee
    {
      public Employee(){
        Name = "";
        Email = "";
        Department = Dept.None;
      }
      public int Id { get; set; }
      
      [Required]
      public string Name { get; set; }
      
      public Dept  Department{ get; set; }
      
      [Required]
      [RegularExpression (@"^[\w\.-]+@[\w\.-]+\.\w+$" , ErrorMessage = "Email invalido")]
      public string? Email { get; set; }
    }
}