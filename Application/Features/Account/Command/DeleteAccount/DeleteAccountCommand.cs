using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Account.Command.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
    }
}
