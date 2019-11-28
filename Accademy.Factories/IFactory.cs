using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accademy.Factories
{
    public interface IFactory<Entity, DTO>
    {
        Entity CreateEntity(DTO dto);
        DTO CreateDto(Entity entity);
    }
}
