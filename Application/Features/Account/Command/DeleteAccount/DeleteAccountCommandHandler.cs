using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Users.Commands.DeleteUser;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Account.Command.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<DeleteUserCommandHandler> _logger;

        public DeleteAccountCommandHandler(IAccountRepository accountRepository, ILogger<DeleteUserCommandHandler> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToDelte = await _accountRepository.GetByIdAsync(request.AccountId);
            
            if (accountToDelte == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Account), request.AccountId);
            }

            await _accountRepository.DeleteAsync(accountToDelte);

            _logger.LogCritical($"Account {accountToDelte.AccountId} has been deleted on {DateTime.Now}");

            return Unit.Value;
        }
    }
}

