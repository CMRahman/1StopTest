using System.Data;
using FluentValidation;

namespace Application.Features.Account.Command.DepositCommand
{
    public class DepositAccountCommandValidator : AbstractValidator<DepositAccountCommand>
    {
        public DepositAccountCommandValidator()
        {

            RuleFor(u => u.AccountId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(u => u.Amount)
                .NotNull()
                .GreaterThan(0.0m).WithMessage("{PropertyName} has to be more than zero");

        }
        
    }
}
