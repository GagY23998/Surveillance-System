﻿using AppCore.Models;
using AppCore.Requests;
using AutoMapper;
using DAL.Data;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
    public class RoleService: CRUDService<Role,RoleDTO,RoleInsertRequest,RoleInsertRequest,RoleSearchRequest>,IRoleService
    {
        public RoleService(AppDbContext context,IMapper mapper):base(context,mapper)
        {

        }
    }
}
