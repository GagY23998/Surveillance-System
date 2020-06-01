using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZavrsniRad.Helpers
{
    public interface IBaseInterface<Entity, EntityDTO, EntityInsertRequest, EntityUpdateRequest, EntitySearchRequest>
        where Entity : class, new()
        where EntityDTO : class, new()
        where EntityInsertRequest : class, new()
        where EntityUpdateRequest : class
    {
        ActionResult<List<EntityDTO>> Get(EntitySearchRequest searchRequest);
        ActionResult<EntityDTO> Get(int id);
        ActionResult<EntityDTO> Post([FromQuery]EntityInsertRequest insertRequest);
        ActionResult<EntityDTO> Put(int Id, [FromQuery]EntityUpdateRequest updateRequest);
        ActionResult<bool> Delete(int id);
        //  ActionResult<IEnumerable<EntityDTO>> GetAll();
    }
}
