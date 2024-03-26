using AutoMapper;
using LoginAPI.Data.DTOs;
using LoginAPI.Models;

namespace LoginAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, ReadUserDTO>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>().ReverseMap();
        }
    }
}
