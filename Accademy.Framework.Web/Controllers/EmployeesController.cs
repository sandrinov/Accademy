using Accademy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accademy.Framework.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private IAccademyData db;
        public EmployeesController()
        {
            db = new AccademyEntityFramework();
        }
        // GET: Employees
        public ActionResult Index()
        {
            var vm = db.GetAllEmployees();
            return View(vm);
        }
        public ActionResult Details(int id)
        {
            var vm = db.GetEmployeeByID(id);
            return View(vm);
        }
        public ActionResult Orders(int id)
        {
            var vm = db.GetAllOrdersByIDEmployee(id);
            return View(vm);
        }
    }
}