using System;
using MediatR;

namespace Application.Features.Account.Command.WithdrawCommand
{
    public class WithdrawFromAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
