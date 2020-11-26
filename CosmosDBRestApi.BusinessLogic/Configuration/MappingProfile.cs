using System;
using AutoMapper;
using CosmosDBRestApi.DataLayer.DataTransferObjects;
using CosmosDBRestApi.DataLayer.DocumentModels.User;

namespace CosmosDBRestApi.BusinessLogic.Configuration
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
