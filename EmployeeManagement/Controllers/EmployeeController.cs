using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>()
        {
        new Employee
            {
                EmployeeId = 101,
                Ename ="Roshni Maurya",
                Department = "HR",
                Designation = "Marketing",
                salary = 45000.00,
                Email = "roshni@gmail.com"
            },
        new Employee
            {
                EmployeeId = 102,
                Ename ="Abhishek Maurya",
                Department = "Fire",
                Designation = "Fire Assistant Officer",
                salary = 55000.00,
                Email = "abhi@gmail.com"
            },
        new Employee
            {
                EmployeeId = 103,
                Ename ="Piyush Dikshit",
                Department = "IT",
                Designation = "Web Developer",
                salary = 60000.00,
                Email = "piya@gmail.com"
            },
        new Employee
            {
                EmployeeId = 104,
                Ename ="Alas Boy",
                Department = "Logistic",
                Designation = "R&D",
                salary = 45000.00,
                Email = "alas@gmail.com"
            },
        };
        public ActionResult Index()
        {
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employees.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public ActionResult Details(int id)
        {
            Employee employee = employees.FirstOrDefault(x => x.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public ActionResult Edits(int id)
        {
            Employee employee = employees.FirstOrDefault(x =>x.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edits(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee existingemployee = employees.FirstOrDefault( x => x.EmployeeId == employee.EmployeeId);
                if (existingemployee == null)
                {
                    existingemployee.Ename = employee.Ename;
                    existingemployee.Department = employee.Department;
                    existingemployee.Designation = employee.Designation;
                    existingemployee.salary = employee.salary;
                    existingemployee.Email = employee.Email;
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(int id) 
        {
          Employee employee = employees.FirstOrDefault(x =>  x.EmployeeId == id);
            if (employee == null)
            {  return HttpNotFound(); }

            employees.Remove(employee);

            return RedirectToAction("Index");
        
        }
    }
}