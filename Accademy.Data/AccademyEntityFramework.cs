using Accademy.Data.EF;
using Accademy.Factories;
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
            emp_factory = new EmployeeFactory();
        }
        public List<AccademyEmployee> GetAllEmployees()
        {
            List<AccademyEmployee> resultList = new List<AccademyEmployee>();
            var listOfEntities =  ctx.Employees.ToList();
            foreach (var entity in listOfEntities)
            {
                resultList.Add(emp_factory.CreateDto(entity));
            }
            return resultList;
        }
        public AccademyEmployee GetEmployeeByID(int EmployeeID)
        {
            return null;
        }
        public List<AccademyOrder> GetAllOrdersByIDEmployee(int EmployeeID)
        {
            return null;
        }
    }
}
