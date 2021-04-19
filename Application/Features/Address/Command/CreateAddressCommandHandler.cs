using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Account.Command.CreateCommand;
using AutoMapper;
using MediatR;

namespace Application.Features.Address.Command
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public CreateAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<Guid> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAddressCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var address = _mapper.Map<Domain.Entities.Address>(request);
            address = await _addressRepository.AddAsync(address);

            return address.AddressId;
        }
    }
}
