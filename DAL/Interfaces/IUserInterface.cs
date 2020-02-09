using AppCore.Models;
using AppCore.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserInterface: ICRUDService<User,UserDTO,UserInsertRequest,UserInsertRequest,UserSearchRequest>
    {
    }
}
