using AppCore.Models;
using AppCore.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ILabelService : ICRUDService<Label,LabelDTO,LabelInsertRequest,LabelInsertRequest,LabelSearchRequest>
    {
    }
}
