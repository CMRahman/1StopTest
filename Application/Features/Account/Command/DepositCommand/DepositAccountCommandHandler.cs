using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Account.Command.DepositCommand
{
    public class DepositAccountCommandHandler : IRequestHandler<DepositAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<DepositAccountCommandHandler> _logger;

        public DepositAccountCommandHandler(IAccountRepository accountRepository,
            ILogger<DepositAccountCommandHandler> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DepositAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.AccountId);
            if (account == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Account), request.AccountId);
            }

            var validator = new DepositAccountCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            account.Balance += request.Amount;


            await _accountRepository.UpdateAsync(account);

            _logger.LogInformation($"Account {account.AccountId} has received deposit on {DateTime.Now}");

            return Unit.Value;

        }
    }
}
