using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavrsniRad.Helpers;

namespace ZavrsniRad.Controllers
{
    public class BaseController<Entity, EntityDTO, EntityInsertRequest, EntityUpdateRequest, EntitySearchRequest> : ControllerBase,
                 IBaseInterface<Entity, EntityDTO, EntityInsertRequest, EntityUpdateRequest, EntitySearchRequest>
     where Entity : class, new()
     where EntityDTO : class, new()
     where EntityInsertRequest : class, new()
     where EntityUpdateRequest : class
     where EntitySearchRequest : class
    {
        public BaseController(ICRUDService<Entity, EntityDTO, EntityInsertRequest, EntityUpdateRequest, EntitySearchRequest> service,
            IMapper myMapper)
        {
            Service = service;
            MyMapper = myMapper;
        }

        public DAL.Interfaces.ICRUDService<Entity, EntityDTO, EntityInsertRequest, EntityUpdateRequest, EntitySearchRequest> Service { get; }
        public IMapper MyMapper { get; }

        [HttpGet("{id}")]
        public ActionResult<EntityDTO> Get(int id)
        {
            var myObject = Service.Get(id);
            return MyMapper.Map<EntityDTO>(myObject);
        }
        [HttpGet]
        public virtual ActionResult<IEnumerable<EntityDTO>> Get([FromQuery]EntitySearchRequest searchRequest)
        {
            var myObjects = Service.Get(searchRequest);
            return myObjects.ToList();
        }
        [HttpPost]
        public ActionResult<EntityDTO> Post(EntityInsertRequest insertRequest)
        {
            var result = Service.Insert(insertRequest);
            return result;
        }
        [HttpPut("{id}")]
        public ActionResult<EntityDTO> Put(int Id, EntityUpdateRequest updateRequest)
        {
            var myObject = Service.Update(Id, updateRequest);
            return myObject;
        }
        [HttpDelete("{id}")]
        public ActionResult<EntityDTO> Delete(int Id)
        {
            var res = Service.Delete(Id);
            return res;
        }
        //[HttpGet]
        //public ActionResult<IEnumerable<EntityDTO>> GetAll()
        //{
        //    var res = Service.GetAll();
        //    return res.ToList();
        //}
    }
}
