using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSquaredApplication.ViewModels;

namespace SSquaredApplication.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee GetEmployee(int? id)
        {
            try
            {
                using (EmployeeEntities employeeModel = new EmployeeEntities())
                {
                    return employeeModel.Employees.Where(emp => emp.EmployeeID == id).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                //handle exception
                return null;
            }
        }

        public List<Employee> GetEmployeesByManagerID(int managerID)
        {
            try
            {
                using (EmployeeEntities employeeModel = new EmployeeEntities())
                {
                    return employeeModel.Employees.Where(emp => emp.ManagerID == managerID).ToList();
                }
            }
            catch (Exception e)
            {
                //handle exception
                return null;
            }
        }

        public List<Employee> GetManagers()
        {
            try
            {
                using (EmployeeEntities employeeModel = new EmployeeEntities())
                {
                    return employeeModel.Employees.Where(emp => emp.EmployeesUnder.Count > 0).ToList();
                }
            }
            catch (Exception e)
            {
                //handle exception
                return null;
            }
        }

        public List<Role> GetRoles()
        {
            try
            {
                using (EmployeeEntities employeeModel = new EmployeeEntities())
                {
                    return employeeModel.Roles.ToList();
                }
            }
            catch (Exception e)
            {
                //handle exception
                return null;
            }
        }

        public Role GetRole(int roleID)
        {
            try
            {
                using (EmployeeEntities employeeModel = new EmployeeEntities())
                {
                    return employeeModel.Roles.Where(role => role.RoleID == roleID).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                //handle exception
                return null;
            }
        }

        public bool CreateEmployee(Employee employeeData)
        {
            try
            {
                using (EmployeeEntities employeeModel = new EmployeeEntities())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = employeeData.EmployeeID;
                    employee.FirstName = employeeData.FirstName;
                    employee.LastName = employeeData.LastName;
                    employee.Manager = employeeData.Manager;
                    employee.Roles = employeeData.Roles;

                    employeeModel.Employees.Add(employee);
                    employeeModel.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                //handle exception
                return false;
            }
        }
    }
}