using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accademy.Data.EF;
using Accademy.Models;

namespace Accademy.Factories
{
    class EmployeeFactory : IFactory<Accademy.Data.EF.Employee, Accademy.Models.AccademyEmployee>
    {
        public AccademyEmployee CreateDto(Employee entity)
        {
            AccademyEmployee dto = new AccademyEmployee()
            {
                IDAccademyEmployee = entity.EmployeeID,
                Nome = entity.FirstName,
                Cognome = entity.LastName,
                Citta = entity.City
            };

            return dto;
        }

        public Employee CreateEntity(AccademyEmployee dto)
        {
            throw new NotImplementedException();
        }
    }
}
