using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries.GetUserAccounts
{
    public class GetUserAccountsQueryHandler : IRequestHandler<GetUserAccountsQuery, List<AccountsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public GetUserAccountsQueryHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public async Task<List<AccountsDto>> Handle(GetUserAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.GetUserAccounts(request.UserId);
            return _mapper.Map<List<AccountsDto>>(accounts);

        }
    }
}
