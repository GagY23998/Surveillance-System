using AppCore.Models;
using AppCore.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRoleService: ICRUDService<Role,RoleDTO,RoleInsertRequest,RoleInsertRequest,RoleSearchRequest>
    {

    }
}
