using System;
using MediatR;

namespace Application.Features.Account.Command.DepositCommand
{
    public class DepositAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
        //public Guid UserId { get; set; }
        public Decimal Amount { get; set; }
        
    }
}
