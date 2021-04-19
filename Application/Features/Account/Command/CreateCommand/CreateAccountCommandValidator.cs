using FluentValidation;

namespace Application.Features.Account.Command.CreateCommand
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {


            RuleFor(u => u.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(u => u.AccountName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

         
        }
    }
}
