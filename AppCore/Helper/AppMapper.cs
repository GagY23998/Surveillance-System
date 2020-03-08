using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AppCore.Models;
using AppCore.Requests;

namespace AppCore.Helper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserInsertRequest>().ReverseMap();
            CreateMap<UserDTO, UserInsertRequest>().ReverseMap();
            CreateMap<UserInsertRequest, UserSearchRequest>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Role, RoleInsertRequest>().ReverseMap();
            CreateMap<RoleDTO, RoleInsertRequest>().ReverseMap();

            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<UserRoleDTO, UserRoleInsertRequest>();
            CreateMap<UserRole, UserRoleInsertRequest>();


            CreateMap<Label, LabelDTO>().ReverseMap();
            CreateMap<LabelDTO, LabelInsertRequest>().ReverseMap();
            CreateMap<Label, LabelInsertRequest>().ReverseMap();


            CreateMap<Log, LogDTO>().ReverseMap();
            CreateMap<LogDTO, LogInsertRequest>().ReverseMap();
            CreateMap<Log, LogInsertRequest>().ReverseMap();

        }
    }
}
