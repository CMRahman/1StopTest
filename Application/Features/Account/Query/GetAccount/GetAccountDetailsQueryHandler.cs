using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Users.Queries.GetUserAccounts;
using AutoMapper;
using MediatR;

namespace Application.Features.Account.Query.GetAccount
{
    public class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery, AccountDto>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public GetAccountDetailsQueryHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public async Task<AccountDto> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _accountRepository.GetByIdAsync(request.AccountId);
            return _mapper.Map<AccountDto>(result);

        }
    }
}
