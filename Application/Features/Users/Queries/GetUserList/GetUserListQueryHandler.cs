using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetUserList
{

    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepository;

        public GetUserListQueryHandler(IMapper mapper,  IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<List<UserListDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var allUsers = (await _userRepository.ListAllAsync()).OrderBy(x => x.LastName);
            return _mapper.Map<List<UserListDto>>(allUsers);

        }
    }
}
