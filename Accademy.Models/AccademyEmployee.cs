using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accademy.Models
{
    public class AccademyEmployee
    {
        [Display(Name ="ID Employee")]
        public int IDAccademyEmployee { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }
        [Display(Name = "Città")]
        public String Citta { get; set; }

        public override string ToString()
        {
            return Nome + " " + Cognome + "\t \t  -- from " + Citta;
        }
    }
}
