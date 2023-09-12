using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using employee_manager.Models;

namespace employee_manager.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IEmployeeRepository _employeeReposotory;
        public ProdutoController(IEmployeeRepository employeeRepository)
        {
            _employeeReposotory = employeeRepository;
        }
        
       public ViewResult Index(){
            IEnumerable<Employee> model = _employeeReposotory.Get_Allemployee();
            ViewBag.All_Employee = model; 
            return View("Index");
       }

       public ViewResult Details(int id = 1){
            Employee model = _employeeReposotory.GetEmployee(id);
            ViewBag.Employee= model;
            return View("Details");
       }

     [HttpGet]
       public ViewResult Create(){
            return View();
       }

     [HttpPost]
       public IActionResult Create(Employee employee){
          if(ModelState.IsValid){
           Employee newEmployee = _employeeReposotory.Add(employee);
           return RedirectToAction("details", new {id = newEmployee.Id});
          }
          return View();
       }

       public ViewResult Edit(int id = 1){
            Employee model = _employeeReposotory.GetEmployee(id);
            ViewBag.Employee= model;
            return View("Edit");
       }
    }
}
