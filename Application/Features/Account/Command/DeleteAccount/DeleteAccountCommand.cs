using System;
using MediatR;

namespace Application.Features.Account.Command.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
    }
}
