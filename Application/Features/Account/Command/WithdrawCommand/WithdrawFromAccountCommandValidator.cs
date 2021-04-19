using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Features.Account.Command.WithdrawCommand
{
    public class WithdrawFromAccountCommandValidator : AbstractValidator<WithdrawFromAccountCommand>
    {
        public WithdrawFromAccountCommandValidator(decimal? balance)
        {
           
            RuleFor(u => u.AccountId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(e => e.Amount)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0.0m).WithMessage("{PropertyName} has to be more than zero");

            RuleFor(e => e)
                .Must(e => e.Amount <= balance)
                .WithMessage("Cannot withdraw amount that exceeds available balance");
        }
    }


}
