using AutoMapper;
using SqlApiBase.DataLayer.DataTransferObjects;
using SqlApiBase.DataLayer.Entities;

namespace SqlApiBase.BusinessLogic.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterUserRequestDto>()
                .ReverseMap();

            CreateMap<User, UpdateUserRequestDto>()
                .ReverseMap();
        }
    }
}
