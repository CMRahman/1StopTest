using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Users.Queries.GetUserAccounts;
using AutoMapper;
using MediatR;

namespace Application.Features.Account.Query.GetAllAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, List<AccountsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public GetAllAccountsQueryHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public async Task<List<AccountsDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var result = await _accountRepository.ListAllAsync();
            return _mapper.Map<List<AccountsDto>>(result);

        }
    }
}
