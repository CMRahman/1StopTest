using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.GetUserList;
using Domain.Entities;
using AutoMapper;
using Application.Features.Users.Queries.GetUserDetails;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<Address, UserAddressDto>().ReverseMap();
            CreateMap<User, UserDetailsDto>();
        }
    }
}
