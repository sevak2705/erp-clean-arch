using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Features.Contact.Commands;
using CleanArchitectureApp.Application.Interfaces;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Contact.Handlers
{
    public class CreateCustomerContactCommandHandler(ICustomerContactRepository customerContactRepository, IMapper mapper) : IRequestHandler<CreateCustomerContactCommand, Unit>
    {
        private readonly ICustomerContactRepository _customerContactRepository = customerContactRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(CreateCustomerContactCommand request, CancellationToken cancellationToken)
        {
            // basic validation
            var validationResult = await new CreateCustomerContactCommandValidator().ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                // Validation failed, throw an exception with the validation errors
                throw new BadRequestException("validationResult.Errors", validationResult);
            }

            // check if contact exist
           var isContactExist = await _customerContactRepository.GetContactByPhoneAsync(request.PhoneNo);

            if(isContactExist.Id > 0)
                throw new ValidationException("Phone number already exists.");

            var customerContact = _mapper.Map<Domain.Entities.CustomerContact>(request);

            // Add to DB
            await _customerContactRepository.CreateAsync(customerContact);

            return Unit.Value;
        }
    }
    
}











































