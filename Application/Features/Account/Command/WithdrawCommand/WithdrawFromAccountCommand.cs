using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Account.Command.WithdrawCommand
{
    public class WithdrawFromAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
