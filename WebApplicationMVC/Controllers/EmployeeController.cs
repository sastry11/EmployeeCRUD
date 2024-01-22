using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GetEmployeeList()
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
            List<Employee> employee = new List<Employee>();
            employee = employeeDBEntities.Employees.ToList();
            return View(employee);
        }

         public ActionResult GetEmployeeByID(int ID)
         {
             EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
             Employee emp = employeeDBEntities.Employees.Find(ID);
             return View(emp);
         }
        
         public ActionResult CreateEmployee(Employee emp)
         {
             EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
             employeeDBEntities.Employees.Add(emp);
             employeeDBEntities.SaveChanges();
             return View();
         }
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
            Employee emp = employeeDBEntities.Employees.Find(id);
            return View(emp);

        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
            Employee emp = employeeDBEntities.Employees.Find(employee.ID);
            emp.FName = employee.FName;
            emp.Department = employee.Department;
            emp.Qualification = employee.Qualification;
            emp.Location = employee.Location;
            employeeDBEntities.SaveChanges();

            return View(emp);
        }
        public ActionResult DeleteEmployee(int id)
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
            Employee emp = employeeDBEntities.Employees.Find(id);
            Employee employee = employeeDBEntities.Employees.Remove(emp);

            return View(employee);
            
        }
    }
}