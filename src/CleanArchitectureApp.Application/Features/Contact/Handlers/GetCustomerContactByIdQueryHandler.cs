using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureApp.Application.Features.Contact.Queries;
using CleanArchitectureApp.Application.Interfaces;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Contact.Handlers
{
    public class GetCustomerContactByIdQueryHandler : IRequestHandler<GetCustomerContactByIdQuery, CustomerContactDto>
    {
        private readonly ICustomerContactRepository _customerContactRepository;
        private readonly IMapper _mapper;
        public GetCustomerContactByIdQueryHandler(ICustomerContactRepository customerContactRepository, IMapper mapper)
        {
            _customerContactRepository = customerContactRepository;
            _mapper = mapper;
        }
        public async Task<CustomerContactDto> Handle(GetCustomerContactByIdQuery request, CancellationToken cancellationToken)
        {
            // Query DB
            var customerContact = await _customerContactRepository.GetByIdAsync(request.Id);

            // convert data object to DTO
            var response= _mapper.Map<CustomerContactDto>(customerContact);

            // return resonse
            return response;
        }
    }

}
