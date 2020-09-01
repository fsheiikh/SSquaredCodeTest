using SSquaredApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSquaredApplication.Models
{
    public interface IEmployeeRepository
    {
       
       Employee GetEmployee(int? id);
       List<Employee> GetEmployeesByManagerID(int managerID);
       List<Employee> GetManagers();
       List<Role> GetRoles();
       Role GetRole(int roleID);
        bool CreateEmployee(Employee employeeData);


    }
}


