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
    public class AccademyEntityFramework : IAccademyData
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
            AccademyEmployee result = new AccademyEmployee();
            var entity = ctx.Employees
                         .Where(e => e.EmployeeID == EmployeeID)
                         .FirstOrDefault();

            result = emp_factory.CreateDto(entity);
            return result;
        }
        public List<AccademyOrder> GetAllOrdersByIDEmployee(int EmployeeID)
        {
            List<AccademyOrder> resultList = new List<AccademyOrder>();
            var result = from e in ctx.Employees
                         join o in ctx.Orders on e.EmployeeID equals o.EmployeeID
                         where e.EmployeeID == EmployeeID
                         select o.Order_Details;

            foreach (var details in result.ToList())
            {
                double amount = 0;
                int orderID = 0;
                DateTime orderDate = DateTime.Now;

                foreach (var detail in details)
                {
                    orderID = detail.OrderID;
                    orderDate = detail.Order.OrderDate.HasValue? detail.Order.OrderDate.Value : DateTime.Now;

                    short qta = detail.Quantity;
                    decimal up = detail.UnitPrice;
                    double tot = (double)(qta * up);                   
                    double discount = tot * detail.Discount;
                    amount += tot - discount;
                }
                AccademyOrder tmp_order = new AccademyOrder()
                {
                    OrderID = orderID,
                    OrderDate = orderDate,
                    OrderAmount = Math.Round(amount, 2)
                };
                resultList.Add(tmp_order);
            }
            return resultList;
        }
        public List<AccademyOrderDetail> GetOrderDetailsByID(int OrderID)
        {
            List<AccademyOrderDetail> resultList = new List<AccademyOrderDetail>();

            var res = ctx.Order_Details.Where(od => od.OrderID == OrderID);

            foreach (var od in res.ToList())
            {
                double tot = od.Quantity * (double)od.UnitPrice;
                double discount = (od.Quantity * (double)od.UnitPrice) * od.Discount;
                AccademyOrderDetail aod = new AccademyOrderDetail()
                {
                    ProductName = od.Product.ProductName,
                    Quantity = od.Quantity,
                    UnityPrice = (double)od.UnitPrice,
                    Discount = Math.Round(discount, 2),
                    Amount = Math.Round(tot - discount, 2)
                };
                resultList.Add(aod);
            }


            return resultList;
        }

    }
}
