using Accademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accademy.Data
{
    public interface IAccademyData
    {
        List<AccademyEmployee> GetAllEmployees();
        AccademyEmployee GetEmployeeByID(int EmployeeID);
        List<AccademyOrder> GetAllOrdersByIDEmployee(int EmployeeID);
        List<AccademyOrderDetail> GetOrderDetailsByID(int OrderID);
    }
}
