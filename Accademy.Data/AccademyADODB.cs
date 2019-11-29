using Accademy.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accademy.Data
{
    public class AccademyADODB : IAccademyData
    {
        private String connString = "";
        private SqlConnection conn;
        private SqlCommand cmd;

        public AccademyADODB()
        {
            connString = "Data Source=DESKTOP-N5TF96M;Initial Catalog=Northwind;Integrated Security=True";
            
            
        }
        public List<AccademyEmployee> GetAllEmployees ()
        {
            List<AccademyEmployee> resultList = new List<AccademyEmployee>();
            

            using (conn = new SqlConnection(connString))
            {
                try
                {
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Employees";
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        AccademyEmployee temp = new AccademyEmployee()
                        {
                            IDAccademyEmployee = (int)dr["EmployeeID"],
                            Nome = dr["FirstName"] as String,
                            Cognome = dr["LastName"] as String,
                            Citta = dr["City"] as String,
                        };
                        resultList.Add(temp);
                    }
                }
                catch (Exception excp)
                {
                    var x = excp;
                }
                finally
                {
                    conn.Close();
                }
            } // conn.Dispose();
            return resultList;
        }

        public AccademyEmployee GetEmployeeByID(int EmployeeID)
        {
            AccademyEmployee result = new AccademyEmployee();
           
            using (conn = new SqlConnection(connString))
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Employees where EmployeeID = " + EmployeeID;
                cmd.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AccademyEmployee temp = new AccademyEmployee()
                    {
                        IDAccademyEmployee = (int)dr["EmployeeID"],
                        Nome = dr["FirstName"] as String,
                        Cognome = dr["LastName"] as String,
                        Citta = dr["City"] as String,
                    };
                    result = temp;
                }
                conn.Close(); 
            }

            return result;
        }

        public List<AccademyOrderDetail> GetOrderDetailsByID(int OrderID)
        {
            return null;
        }

        public List<AccademyOrder> GetAllOrdersByIDEmployee(int EmployeeID)
        {
            List<AccademyOrder> resultList = new List<AccademyOrder>();
                        using (conn = new SqlConnection(connString))
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Orders.OrderID, Orders.OrderDate, [Order Details].UnitPrice, [Order Details].Quantity, [Order Details].Discount, Employees.EmployeeID " +
                              "FROM Orders INNER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID INNER JOIN " +
                              "[Order Details] ON Orders.OrderID = [Order Details].OrderID " +
                              "WHERE(Employees.EmployeeID = " + EmployeeID + ")";
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int tmpID = -1;

                bool fine = !dr.Read();

                if (!fine)
                {
                    tmpID = (int)dr["OrderID"];
                }
                while (!fine)
                {
                    double amount = 0;
                    DateTime orderDate = (DateTime)dr["OrderDate"];
                    while (!fine && tmpID == (int)dr["OrderID"])
                    {
                        Int16 qta = (Int16)dr["Quantity"];
                        decimal up = (decimal)dr["UnitPrice"];
                        double tot = (double)(qta * up);
                        Double discount = (double)(tot * (Single)dr["Discount"]);
                        amount += (tot - discount);
                        fine = !dr.Read();
                    }
                    AccademyOrder tmp_order = new AccademyOrder()
                    {
                        OrderID = tmpID,
                        OrderDate = orderDate,
                        OrderAmount = Math.Round(amount, 2)
                    };
                    resultList.Add(tmp_order);
                    if (!fine)
                    {
                        tmpID = (int)dr["OrderID"];
                    }
                }

                conn.Close(); 
            }
            return resultList;
        }

    }
}
