using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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
                .MustAsync(StateAndPostCodeValid)
                .WithMessage("Please provide a valid state and postcode");


        }

        private async Task<bool> StateAndPostCodeValid(CreateAddressCommand arg, CancellationToken token)
        {
            //TODO : Change validation to use real data instead of static List of States & Codes

            /**********************************************************************************
             *
            Currently this method calls an Azure Function for validation.
            Validation is being done against a static list of States and PostCodes.

            Valid States and PostCode lists >>

            List<string> states = new List<string> { "NSW", "ACT", "QLD", "VIC", "SA" };
            List<int> postCodes = Enumerable.Range(2500, 1000).ToList();

            **********************************************************************************/

            bool isValid = false;

            using (var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://validateaddress.azurewebsites.net")
            })
            {
                var response = await httpClient.GetAsync($"api/ValidateAddress?state={arg.State}&postcode={arg.PostCode}");

                if (response.IsSuccessStatusCode)
                {
                    string resultContent = await response.Content.ReadAsStringAsync(token);
                    isValid = resultContent.Contains("valid");

                }
            }

            return await Task.FromResult(isValid);
        }

       

    }
}
