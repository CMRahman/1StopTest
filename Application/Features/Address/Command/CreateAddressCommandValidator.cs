using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Application.Features.Address.Command
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    { 
        public CreateAddressCommandValidator()
        {
           
            RuleFor(u => u.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(e => e)
                .Must(IsValidStateAndPostCode)
                .WithMessage("Please provide a valid state and postcode");


        }

        private bool IsValidStateAndPostCode(CreateAddressCommand arg)
        {
            return _states.Any(str => str.Contains(arg.State))
                && _postCodes.Any(codes => codes.Equals(arg.PostCode));
        }


        private readonly List<string> _states = new List<string> {"NSW", "ACT", "QLD", "VIC", "SA"};
        private readonly List<int> _postCodes = Enumerable.Range(2500, 1000).ToList();

    }
}
