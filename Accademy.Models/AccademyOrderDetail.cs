using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accademy.Models
{
    public class AccademyOrderDetail
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnityPrice { get; set; }
        public double Discount { get; set; }
        public double Amount { get; set; }

    }
}
