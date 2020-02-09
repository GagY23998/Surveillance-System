using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CORE.Models;
using CORE.Requests;

namespace CORE.Helper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserInsertRequest>().ReverseMap();
            CreateMap<UserDTO, UserInsertRequest>().ReverseMap();

            CreateMap<Label, LabelDTO>().ReverseMap();
            CreateMap<LabelDTO, LabelInsertRequest>().ReverseMap();
            CreateMap<Label, LabelInsertRequest>().ReverseMap();

        }
    }
}
