using System;
using MediatR;

namespace Application.Features.Account.Command
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public string AccountName { get; set; }
        public decimal? Balance { get; set; }
        public Guid UserId { get; set; }
    }
}
