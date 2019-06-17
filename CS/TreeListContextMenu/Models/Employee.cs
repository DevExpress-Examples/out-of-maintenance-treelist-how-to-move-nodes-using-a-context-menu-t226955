using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeListContextMenu.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int? ReportsTo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
    }
}