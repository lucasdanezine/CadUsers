using AutoMapper;
using CadUsers.Entities.DTOs;
using CadUsers.Entities.Models;

namespace CadUsers.API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<ContactDto, Contact>();
            CreateMap<Contact, ContactDto>();

        }
    }
}
