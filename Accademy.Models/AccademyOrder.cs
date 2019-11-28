using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accademy.Models
{
    public class AccademyOrder
    {
        public AccademyOrder()
        {

        }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderAmount { get; set; }

        public override string ToString()
        {
            return OrderID + " " + OrderDate.ToShortDateString() + " " + OrderAmount;
        }
    }
}
