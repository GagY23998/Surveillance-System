using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Models;
using AppCore.Requests;
using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZavrsniRad.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace reactApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LabelController : BaseController<Label,LabelDTO,LabelInsertRequest,LabelInsertRequest,LabelSearchRequest>
    {
        public LabelController(ILabelService service,IMapper myMapper):base(service,myMapper)
        {

        }
    }
}
