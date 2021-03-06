﻿using System;
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
using Microsoft.AspNetCore.SignalR;
using reactApp.Hubs;
using Newtonsoft.Json;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace reactApp.Controllers
{

    public class VisitsDTO
    {
        public List<LogDTO> visitsToday { get; set; }
        public List<LogDTO> visitsMonth { get; set; }
    }
    
    [Authorize(Roles="Admin,User")]
    [ApiController]
    [Route("api/[controller]")]
    public class ArchiveController : BaseController<Log,LogDTO,LogInsertRequest,LogInsertRequest,LogSearchRequest>
    {
        // GET: api/<controller>
        IHubContext<ArchiveHub> _hubContext;
        public ArchiveController(ILogInterface service,IMapper mapper,IHubContext<ArchiveHub> hubContext):base(service,mapper)
        {
            _hubContext = hubContext;
        }

        [Authorize(Roles ="Admin")]
        public override ActionResult<LogDTO> Post(LogInsertRequest insertRequest)
        {
            var res = base.Post(insertRequest);
            if(res.Value != null)
            {
                _hubContext.Clients.All.SendAsync("RecieveMessage",res.Value);
            }
            return res;
        }
        [Authorize(Roles="Admin")]
        public override ActionResult<LogDTO> Put(int Id, LogInsertRequest updateRequest)
        {
            var res =  base.Put(Id, updateRequest);
            if (res.Value != null)
            {
                _hubContext.Clients.All.SendAsync("UpdateMessage", res.Value);
            }
            return res;
        }
        [Authorize(Roles="Admin,User")]
        [HttpGet("visitstoday")]
        public List<LogDTO> VisitsToday() 
        {
            var Date = DateTime.Now;
            var zeroHours = Date.AddHours(-Date.Hour).AddMinutes(-Date.Minute).AddSeconds(-Date.Second);
            var lastHour = Date.AddHours(-Date.Hour+24).AddMinutes(-Date.Minute).AddSeconds(-Date.Second);
         
            //var firstDate = DateTime.Now.AddDays(-DateTime.Now.Day).AddHours(-DateTime.Now.Hour).AddMinutes(-DateTime.Now.Minute).AddSeconds(-DateTime.Now.Second).AddDays(1);
            //var lastDate = firstDate.AddDays(DateTime.DaysInMonth(firstDate.Year, firstDate.Month)).AddDays(-1);

            var visitsToday = Service.Get(new LogSearchRequest { FromDate = zeroHours, ToDate = lastHour});
            //var visitsToday = Service.Get(new LogSearchRequest { FromDate = zeroHours, ToDate = lastHour});
            //var visitsMonth = Service.Get(new LogSearchRequest { FromDate =firstDate ,ToDate = lastDate});

            //var visitInfo = new VisitsDTO
            //{
            //    visitsToday = visitsToday,
            //    visitsMonth = visitsMonth
            //};

            //return visitInfo;        
            return visitsToday;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("visitsmonth")]
        public List<LogDTO> VisitsMonth()
        {
            var firstDate = DateTime.Now.AddDays(-DateTime.Now.Day).AddHours(-DateTime.Now.Hour).AddMinutes(-DateTime.Now.Minute).AddSeconds(-DateTime.Now.Second).AddDays(1);
            var lastDate = firstDate.AddDays(DateTime.DaysInMonth(firstDate.Year, firstDate.Month)).AddDays(-1);

            var visitsMonth = Service.Get(new LogSearchRequest { FromDate =firstDate ,ToDate = lastDate});

            return visitsMonth;
        }

        [Authorize(Roles="Admin,User")]
        [HttpGet("currentEntries")]
        public List<LogDTO> CurrentEntries()
        {
            var res = Service.Get(new LogSearchRequest { FromDate = default(DateTime).AddHours(1), ToDate= default(DateTime).AddHours(1),Entered = true, Left = false });

            return res;
        }

    }
}
