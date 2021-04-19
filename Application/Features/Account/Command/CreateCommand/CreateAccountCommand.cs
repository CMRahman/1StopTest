using System;
using MediatR;

namespace Application.Features.Account.Command.CreateCommand
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal? Balance { get; set; }
        public Guid UserId { get; set; }
    }
}
