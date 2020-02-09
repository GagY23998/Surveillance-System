using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AppCore.Models;
using AppCore.Requests;
using DAL.Data;
using DAL.Interfaces;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;
using ZavrsniRad.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace reactApp.Controllers
{

    public class VisitsDTO
    {
        public List<LogDTO> visitsToday { get; set; }
        public List<LogDTO> visitsMonth { get; set; }
        public int TotalVisits { get; set; }
    }
    
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ArchiveController : BaseController<Log,LogDTO,LogInsertRequest,LogInsertRequest,LogSearchRequest>
    {
        // GET: api/<controller>
        public ArchiveController(ILogInterface service,IMapper mapper):base(service,mapper)
        {
           
        }



        [HttpGet("visits")]
        public VisitsDTO Visits() 
        {
            var Date = DateTime.Now;
            var zeroHours = Date.AddHours(-Date.Hour).AddMinutes(-Date.Minute).AddSeconds(-Date.Second);
            var lastHour = Date.AddHours(-Date.Hour+24).AddMinutes(-Date.Minute).AddSeconds(-Date.Second);
         
            var firstDay = Date.AddDays(-Date.Day);
            var lastDay = Date.AddDays(-Date.Day + DateTime.DaysInMonth(Date.Year,Date.Month));

            var visitsToday = Service.Get(new LogSearchRequest { FromDate = zeroHours, ToDate = lastHour});
            var visitsMonth = Service.Get(new LogSearchRequest { FromDate =firstDay ,ToDate = lastDay});
            var visitInfo = new VisitsDTO
            {
                visitsToday = visitsToday,
                visitsMonth = visitsMonth,
                TotalVisits = Service.Get(null).Count()
            };

            return visitInfo;        
        }

    }
}
