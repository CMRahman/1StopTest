using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Account.Command.WithdrawCommand
{
    public class WithdrawFromAccountCommandHandler : IRequestHandler<WithdrawFromAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<WithdrawFromAccountCommandHandler> _logger;

        public WithdrawFromAccountCommandHandler(IAccountRepository accountRepository, ILogger<WithdrawFromAccountCommandHandler> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(WithdrawFromAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToUpdate = await _accountRepository.GetByIdAsync(request.AccountId);
            if (accountToUpdate == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Account), request.AccountId);
            }

            var validator = new WithdrawFromAccountCommandValidator(accountToUpdate.Balance);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            accountToUpdate.WithdrawAccount(request.Amount);
            
            await _accountRepository.UpdateAsync(accountToUpdate);

            return Unit.Value;


        }
    }
}
