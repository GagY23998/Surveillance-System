using AutoMapper;
using AppCore.Models;
using AppCore.Requests;
using DAL.Data;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Services
{
    public class LogService: CRUDService<Log,LogDTO,LogInsertRequest,LogInsertRequest,LogSearchRequest>,ILogInterface
    {
        public LogService(AppDbContext context,IMapper mapper):base(context,mapper)
        {

        }
        public override List<LogDTO> Get(LogSearchRequest searchRequest)
        {
            if (searchRequest==null)
            {
                return MyMapper.Map<List<LogDTO>>(_context.Set<Log>().AsQueryable().ToList());
            }
            if(searchRequest.Id != 0)
            {
                var res = _context.Log.Find(searchRequest.Id);
                return MyMapper.Map<List<LogDTO>>(new List<Log> { res });
            }


            var query = _context.Set<Log>().AsQueryable();

            query = query.Include(_ => _.User);

            if (searchRequest.UserId == 0)
            {
                if (!string.IsNullOrEmpty(searchRequest.FirstName) || !string.IsNullOrEmpty(searchRequest.LastName))
                {
                    query = query.Where(_ => (_.User.FirstName == searchRequest.FirstName || _.User.LastName == searchRequest.LastName) && _.UserId.HasValue);
                }

            }
            else
            {
                query = query.Where(_ => _.UserId == searchRequest.UserId);
            }
            if ((searchRequest.FromDate == new DateTime(1,1,1,1,0,0) || searchRequest.FromDate == default(DateTime) ) ||
                (searchRequest.ToDate == new DateTime(1,1,1,1,0,0) || searchRequest.ToDate == default(DateTime)))
            {
                query = query.Where(_ => (_.EnteredDate.HasValue && (_.EnteredDate >= DateTime.MinValue && _.EnteredDate <= DateTime.MaxValue)) ||
                         (_.LeftDate.HasValue && (_.LeftDate >= DateTime.MinValue && _.LeftDate <= DateTime.MaxValue)));

            }
            else
            {
                query = query.Where(_ => (_.EnteredDate.HasValue && (_.EnteredDate >= searchRequest.FromDate && _.EnteredDate <= searchRequest.ToDate)) ||
                                         (_.LeftDate.HasValue && (_.LeftDate >= searchRequest.FromDate && _.LeftDate <= searchRequest.ToDate)));
            }
            
            if (searchRequest.Entered.HasValue)
            {
                query = query.Where(_ => _.Entered == searchRequest.Entered );
            }
            
            
            if (searchRequest.Left.HasValue)
            {
                query = query.Where(_ => _.Left == searchRequest.Left);
            }
            

            return MyMapper.Map<List<LogDTO>>(query.ToList());
        }
        public override LogDTO Insert(LogInsertRequest InsertRequest)
        {
            var res =  base.Insert(InsertRequest);
            var includeRes = _context.Log.Include(_ => _.User).FirstOrDefault(_ => _.Id == res.Id);
            return MyMapper.Map<LogDTO>(includeRes);
        }

        public override LogDTO Update(int objectId, LogInsertRequest updateRequest)
        {
            var res =  base.Update(objectId, updateRequest);
            var includeRes = _context.Log.Include(_ => _.User).FirstOrDefault(_ => _.Id == res.Id);
            return MyMapper.Map<LogDTO>(includeRes);

        }
    }
}
