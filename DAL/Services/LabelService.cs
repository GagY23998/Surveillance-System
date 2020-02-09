using AppCore.Models;
using AppCore.Requests;
using AutoMapper;
using DAL.Data;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
    public class LabelService: CRUDService<Label,LabelDTO,LabelInsertRequest,LabelInsertRequest,LabelSearchRequest>,ILabelService
    {
        public LabelService(AppDbContext context,IMapper myMapper):base(context,myMapper)
        {

        }
    }
}
