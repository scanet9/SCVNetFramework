using System;
using AutoMapper;
using CosmosApiBase.DataLayer.DataTransferObjects;
using CosmosApiBase.DataLayer.DocumentModels.User;

namespace CosmosApiBase.BusinessLogic.Configuration
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
