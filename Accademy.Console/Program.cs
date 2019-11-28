using Accademy.Data;
using Accademy.Data.EF;
using Accademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accademy.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x = 10;
            //int y = 20;
            //String result = "Risultato somma: ";
            //int res = Somma(x, y);
            //result += res;
            //System.Console.WriteLine(result);

            //PrintEmployees();
            //System.Console.WriteLine("--------------------------");
            //PrintEmployee(2);
            //PrintOrders(9);

            //PrintEmployeesEF();
            PrintOrdersEF(2);
        }

        private static void PrintEmployeesEF()
        {
            NorthwindEntities ctx = new NorthwindEntities();
            //var result = from e in ctx.Employees
            //             orderby e.LastName
            //             select e;

            var result = ctx.Employees.OrderBy(e => e.LastName);

            foreach (var emp in result.ToList())
            {
                System.Console.WriteLine(emp.FirstName + " " + emp.LastName);
            }
                         
        }
        private static void PrintOrdersEF(int EmployeeID)
        {
            NorthwindEntities ctx = new NorthwindEntities();
            var result = from e in ctx.Employees
                         join o in ctx.Orders on e.EmployeeID equals o.EmployeeID
                         where e.EmployeeID == EmployeeID
                         select o.Order_Details;

            foreach (var details in result.ToList())
            {
                foreach (var detail in details)
                {
                    System.Console.WriteLine(detail.OrderID + " " + 
                                             detail.Product.ProductName + " " + 
                                             detail.Quantity);
                }
            }
                         
        }
        private static void PrintOrders(int EmployeeID)
        {
            AccademyADODB db = new AccademyADODB();
            List<AccademyOrder> lst = db.GetAllOrdersByIDEmployee(EmployeeID);
            foreach (AccademyOrder ord in lst)
            {
                System.Console.WriteLine(ord);
            }
        }

        private static void PrintEmployee(int EmployeeID)
        {
            AccademyADODB db = new AccademyADODB();
            AccademyEmployee emp = db.GetEmployeeByID(EmployeeID);
            System.Console.WriteLine(emp);
        }
        private static void PrintEmployees()
        {
            AccademyADODB db = new AccademyADODB();
            List<AccademyEmployee> lst = db.GetAllEmployees();

            foreach (AccademyEmployee emp in lst)
            {
                System.Console.WriteLine(emp);
            }
        }
        private static int Somma(int x, int y)
        {
            return x + y;
        }
    }
}
