using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Ename { get; set; }
        public string Department { get; set; }
        public string Designation {  get; set; }
        public double salary { get; set; }
        public string Email { get; set; }

    }
}