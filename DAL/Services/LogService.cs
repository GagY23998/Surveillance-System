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

            var query = _context.Set<Log>().AsQueryable();

            query = query.Include(_ => _.User);
            query = query.Where(_ => _.TimeStamp > searchRequest.FromDate && _.TimeStamp < searchRequest.ToDate);

            if(searchRequest.UserId == 0)
            {
                if(!(string.IsNullOrEmpty(searchRequest.FirstName) || string.IsNullOrEmpty(searchRequest.LastName)))
                {
                    query = query.Where(_ => _.User.FirstName == searchRequest.FirstName || _.User.LastName == searchRequest.LastName);
                }

            }
            else
            {
                query = query.Where(_ => _.UserId == searchRequest.UserId);
            }

            if(searchRequest.Entered.HasValue && searchRequest.Left.HasValue)
            {
                query = query.Where(_ => _.Entered == searchRequest.Entered.Value || _.Left == searchRequest.Left.Value);

            }
    


            return MyMapper.Map<List<LogDTO>>(query.ToList());
        }
    }
}
