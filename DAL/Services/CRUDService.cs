using AutoMapper;
using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace DAL.Services
{
    public class CRUDService<Entity, EntityDTO, InsertRequest, UpdateRequest, SearchRequest> :
                 ICRUDService<Entity, EntityDTO, InsertRequest, UpdateRequest, SearchRequest>
                     where Entity : class, new()
                     where EntityDTO : class, new()
                     where InsertRequest : class, new()
                     where UpdateRequest : class
                     where SearchRequest : class, new()
    {
        public CRUDService(AppDbContext context, IMapper myMapper)
        {
            _context = context;
            MyMapper = myMapper;
        }

        public AppDbContext _context { get; }
        public IMapper MyMapper { get; }
        //public EntityDTO Delete(int Id)
        //{
        //    var myObject = _context.Find<Entity>(Id);
        //    _context.Remove(myObject);
        //    _context.SaveChanges();
        //    return MyMapper.Map<EntityDTO>(myObject);
        //}

        private object GetDefaultTypeValue(Type myType)
        {
            if (myType.IsValueType && Nullable.GetUnderlyingType(myType) == null)
            {
                return Activator.CreateInstance(myType);
            }
            return null;
        }

        private IQueryable<Entity> SearchWhereClause(IQueryable<Entity> query, SearchRequest searchObject, string childProperty = "")
        {

            var properties = searchObject.GetType().GetProperties();
            var myentity = Activator.CreateInstance<Entity>();
            var entityProperties = myentity.GetType().GetProperties().Select(_ => _.Name).ToList();
            foreach (var property in properties)
            {
                if (!entityProperties.Contains(property.Name))
                {
                    continue;
                }


                var propertyType = property.PropertyType;
                var defaultVal = this.GetDefaultTypeValue(propertyType);
                var propertyValue = property.GetValue(searchObject, null);

                if (propertyValue == null) continue;
                if (propertyType == typeof(DateTime) && ((DateTime)propertyValue).Hour != 0)
                {
                    propertyValue = ((DateTime)propertyValue).AddHours(-1);
                }
                if (propertyValue.Equals(defaultVal))
                {
                    continue;
                }
                var propertyName = childProperty != "" ? $"{childProperty}.{property.Name}" : property.Name;


                var value = property.PropertyType == typeof(string) ? $"\"{property.GetValue(searchObject, null)}\"" : property.GetValue(searchObject, null);

                query = query.Where($"{property.Name}={value}");
            }

            return query;
        }

        public IQueryable<Entity> SetIncludes(IQueryable<Entity> query,object request)
        {

            foreach (var prop in request.GetType().GetProperties())
            {

                if(prop.PropertyType == typeof(string) ||
                   prop.PropertyType.IsValueType ||
                   prop.PropertyType == typeof(DateTime))
                {
                    continue;
                }
                var res =prop.GetValue(request,null);
                if(res == null)
                {
                    continue;
                }
                query.Include($"{prop.Name}");
            }
            return query;
        }


        public EntityDTO Get(int id)
        {
            var myObject = _context.Find<Entity>(id);
            return MyMapper.Map<EntityDTO>(myObject);
        }
        public IEnumerable<EntityDTO> GetAll()
        {
            var myObjects = _context.Set<Entity>().ToList();
            return MyMapper.Map<List<EntityDTO>>(myObjects);
        }

        //public virtual IEnumerable<EntityDTO> Get(SearchRequest searchRequest)
        public virtual List<EntityDTO> Get(SearchRequest searchRequest)
        {
            var myQuery = _context.Set<Entity>().AsQueryable();

            myQuery = SearchWhereClause(myQuery, searchRequest);
            myQuery = SetIncludes(myQuery, searchRequest);
            //if (myQuery.Count() == 0)
            //{
            //    return MyMapper.Map<IEnumerable<EntityDTO>>(_eTravelContext.Set<Entity>().ToList());
            //}
            

            var myResult = myQuery.ToList();

            var returnObject = MyMapper.Map<List<EntityDTO>>(myResult);
            return returnObject;
        }

        public virtual EntityDTO Insert(InsertRequest InsertRequest)
        {
            var myObject = MyMapper.Map<InsertRequest, Entity>(InsertRequest);
            try
            {
                _context.Add(myObject);
                _context.SaveChanges();
               
            }
            catch (Exception e)
            {
                return null;
            }

            return MyMapper.Map<EntityDTO>(myObject);
        }
        public virtual EntityDTO Update(int objectId, UpdateRequest updateRequest)
        {
            Entity myObject = _context.Find<Entity>(objectId);
            if (myObject == null)
            {
                return MyMapper.Map<EntityDTO>(updateRequest);
            }
            _context.Entry<Entity>(myObject).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            var map = MyMapper.Map<Entity>(updateRequest);
            map.GetType().GetProperty("Id").SetValue(map, objectId);
            _context.Update(map);
            _context.SaveChanges();
            
            var res=  MyMapper.Map<EntityDTO>(updateRequest);
            res.GetType().GetProperty("Id").SetValue(res, objectId);
            return res;
        }
        public virtual bool Delete(int id)
        {
            Entity target = _context.Find<Entity>(id);
            if(target == null)
            {
                return false;
            }
            _context.Remove(target);
            _context.SaveChanges();
            return true;
        }
    }
}
