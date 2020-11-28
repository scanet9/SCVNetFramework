using System;
using AutoMapper;
using SCVCosmosFramework.DataLayer.DataTransferObjects;
using SCVCosmosFramework.DataLayer.DocumentModels.User;

namespace SCVCosmosFramework.BusinessLogic.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterUserDto>()
                .ReverseMap();

            CreateMap<User, UpdateUserDto>()
                .ReverseMap();
        }
    }
}
