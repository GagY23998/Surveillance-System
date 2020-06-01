using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Models;
using AppCore.Requests;
using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ZavrsniRad.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace reactApp.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : BaseController<Role,RoleDTO,RoleInsertRequest,RoleInsertRequest,RoleSearchRequest>
    {
        public RoleController(IRoleService service,IMapper mapper):base(service,mapper)
        {

        }
     
    }
}
