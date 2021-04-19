using System;
using MediatR;

namespace Application.Features.Address.Command
{
    public class CreateAddressCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string State { get; set; }
        public int PostCode { get; set; }
    }
}
