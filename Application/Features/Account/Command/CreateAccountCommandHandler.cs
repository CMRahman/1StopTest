using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Users.Commands.CreateUser;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Account.Command
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository, ILogger<CreateUserCommandHandler> logger)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAccountCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var account = _mapper.Map<Domain.Entities.Account>(request);
            account = await _accountRepository.AddAsync(account);

            _logger.LogInformation($"Account: {account.AccountId} created on {DateTime.Now}");

            return account.AccountId;

        }
    }
}