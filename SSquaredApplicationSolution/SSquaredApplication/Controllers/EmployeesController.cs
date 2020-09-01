using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSquaredApplication.Models;
using SSquaredApplication.Utility;
using SSquaredApplication.ViewModels;

namespace SSquaredApplication.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index(int managerID = 1)
        {
            EmployeeListViewModel employeeListViewModel = EmployeeUtility.GetEmployeeViewModelByManagerID(managerID);

            return View(employeeListViewModel);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            CreateEmployeeViewModel createEmployeeViewModel = EmployeeUtility.GetCreateEmployeeViewModel();

            return View(createEmployeeViewModel);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel employeeFormData)
        {
            try
            {
                EmployeeUtility.SubmitNewEmployeeData(employeeFormData);

                return RedirectToAction("Index", "");
            }
            catch
            {
                return View();
            }
        }
    }
}
