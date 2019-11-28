using Accademy.Data.EF;
using Accademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accademy.Data
{
    public class AccademyEntityFramework
    {
        private NorthwindEntities ctx;
        public AccademyEntityFramework()
        {
            ctx = new NorthwindEntities();
        }
        public List<AccademyEmployee> GetAllEmployees()
        {
            return ctx.Employees.ToList();
        }
        public AccademyEmployee GetEmployeeByID(int EmployeeID)
        {

        }
        public List<AccademyOrder> GetAllOrdersByIDEmployee(int EmployeeID)
        {

        }
    }
}
