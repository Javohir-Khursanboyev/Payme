using AutoMapper;
using Payme.Domain.Entities.Users;
using Payme.Service.DTOs.Users;

namespace Payme.Service.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserViewModel>().ReverseMap();
        CreateMap<User, UserCreationModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
    }
}
