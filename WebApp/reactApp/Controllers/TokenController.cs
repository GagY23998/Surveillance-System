using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AppCore.Requests;
using AutoMapper;
using DAL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace reactApp.Controllers { 
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        AppDbContext _context;
        IConfiguration _configuration;
        IMapper MyMapper;

        public TokenController(IConfiguration configuration,AppDbContext context,IMapper myMapper)
        {
            _context = context;
            _configuration = configuration;
            MyMapper = myMapper;
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }


        [HttpPost]
        public UserDTO Post([FromBody]UserInsertRequest request)
        {
            var searchRequest = MyMapper.Map<UserSearchRequest>(request);
            var user = _context.Users.FirstOrDefault(_ => _.UserName == request.UserName);
            var password = GenerateHash(user.PasswordSalt, request.Password);


            if (user.PasswordHash == password)
            {

                var claims = new Claim[]
                {
                    new Claim("Id",user.Id.ToString()),
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(JwtRegisteredClaimNames.Aud,_configuration["Jwt:Audience"])
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], audience: _configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(5),signingCredentials:signInCredentials);
                var writeToken= new JwtSecurityTokenHandler().WriteToken(token);
                user.Token = writeToken;
                _context.Users.Update(user);
                _context.SaveChanges();
                return MyMapper.Map<UserDTO>(user);

            }
            else
            {
                return null;
            }
        }


    }
}
