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
        private EmployeeFactory emp_factory;
        public AccademyEntityFramework()
        {
            ctx = new NorthwindEntities();
        }
        public List<AccademyEmployee> GetAllEmployees()
        {
            List<AccademyEmployee> resultList = new List<AccademyEmployee>();
            var listOfEntities =  ctx.Employees.ToList();
            foreach (var entity in listOfEntities)
            {
                resultList.
            }

        }
        public AccademyEmployee GetEmployeeByID(int EmployeeID)
        {

        }
        public List<AccademyOrder> GetAllOrdersByIDEmployee(int EmployeeID)
        {

        }
    }
}
