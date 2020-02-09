using AppCore.Models;
using AppCore.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ILogInterface: ICRUDService<Log,LogDTO,LogInsertRequest,LogInsertRequest,LogSearchRequest>
    {
    }
}
