using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSquaredApplication.Models;

namespace SSquaredApplication.ViewModels
{
    public class EmployeeListViewModel
    {
        public Employee Manager { get; set; }
        public List<Employee> Employees { get; set; }

        public SelectList ManagerID { get; set; }
        
        public List<Employee> Managers { get; set; }
    }
}