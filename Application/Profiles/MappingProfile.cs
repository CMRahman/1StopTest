using Application.Features.Users.Queries.GetUserList;
using Domain.Entities;
using AutoMapper;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserListDto>().ReverseMap();
        }
    }
}
