using AppCore.Models;
using AppCore.Requests;
using AutoMapper;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
    public class UserRoleService: CRUDService<UserRole,UserRoleDTO,UserRoleInsertRequest,UserRoleInsertRequest,UserRoleSearchRequest>
    {
        public UserRoleService(AppDbContext context,IMapper mapper):base(context,mapper)
        {
            
        }
    }
}
