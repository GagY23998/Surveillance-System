using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using AppCore.Requests;
using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using reactApp.Helpers;
using ZavrsniRad.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace reactApp.Controllers
{
    [Authorize(AuthenticationSchemes ="Bearer",Policy ="Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User,UserDTO,UserInsertRequest,UserInsertRequest,UserSearchRequest>
    {
        
        public UserController(IUserInterface service,IMapper mapper):base(service,mapper)
        {
        }

        
    }
}
