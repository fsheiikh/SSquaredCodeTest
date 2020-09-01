using SSquaredApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSquaredApplication.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public List<Employee> Managers { get; set; }
        public Employee Employee { get; set; }
        public List<Role> Roles { get; set; }
        public List<int> RoleIDs { get; set; }
    }
}