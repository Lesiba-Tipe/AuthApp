using AuthApp.Dto;
using AuthApp.Entity;
using AuthApp.Input;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User,RegisterInput>();
            CreateMap<User,GoogleRegisterInput>();
            CreateMap<Building, BuildingDto>().ReverseMap();
        }
    }
}
