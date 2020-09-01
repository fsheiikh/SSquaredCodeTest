using SSquaredApplication.Models;
using SSquaredApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSquaredApplication.Utility
{
    public class EmployeeUtility
    {
        public static EmployeeListViewModel GetEmployeeViewModelByManagerID(int managerID)
        {
            EmployeeListViewModel employeesViewModel = new EmployeeListViewModel();
            EmployeeRepository employeeRepo = new EmployeeRepository();

            employeesViewModel.Employees = employeeRepo.GetEmployeesByManagerID(managerID);
            employeesViewModel.Manager = employeeRepo.GetEmployee(managerID);
            employeesViewModel.Managers = employeeRepo.GetManagers();

            return employeesViewModel;

        }

        public static EmployeeListViewModel GetEmployeeViewModelEmpty()
        {
            EmployeeListViewModel employeesViewModel = new EmployeeListViewModel();
            EmployeeRepository employeeRepo = new EmployeeRepository();

            employeesViewModel.Managers = employeeRepo.GetManagers();

            return employeesViewModel;
        }

        public static CreateEmployeeViewModel GetCreateEmployeeViewModel()
        {
            CreateEmployeeViewModel createEmployeeViewModel = new CreateEmployeeViewModel();
            EmployeeRepository employeeRepo = new EmployeeRepository();

            createEmployeeViewModel.Managers = employeeRepo.GetManagers();
            createEmployeeViewModel.Roles = employeeRepo.GetRoles();

            return createEmployeeViewModel;
        }

        public static bool SubmitNewEmployeeData(CreateEmployeeViewModel createEmployeeViewModel)
        {
            Employee employee = new Employee();
            EmployeeRepository employeeRepo = new EmployeeRepository();

            employee.EmployeeID = createEmployeeViewModel.Employee.EmployeeID;
            employee.FirstName = createEmployeeViewModel.Employee.FirstName;
            employee.LastName = createEmployeeViewModel.Employee.LastName;
            employee.Roles = GetSelectedRolesFromList(createEmployeeViewModel.RoleIDs);
            employee.Manager = employeeRepo.GetEmployee(createEmployeeViewModel.Employee.ManagerID);

            return employeeRepo.CreateEmployee(employee);
        }

        private static List<Role> GetSelectedRolesFromList(List<int> RoleIDs)
        {
            try
            {
                EmployeeRepository employeeRepo = new EmployeeRepository();
                List<Role> roles = new List<Role>();
                foreach (int roleId in RoleIDs)
                {
                    roles.Add(employeeRepo.GetRole(roleId));
                }
                return roles;
            }
            catch (Exception e)
            {
                //handle exception
                return null;
            }
        }
    }
}