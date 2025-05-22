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
    public class GetCustomerContactQueryHandler
        : IRequestHandler<GetCustomerContactQuery, List<CustomerContactDto>>
    {
        private readonly ICustomerContactRepository _customerContactRepository;
        private readonly IMapper _mapper;

        public GetCustomerContactQueryHandler(
            ICustomerContactRepository customerContactRepository,
            IMapper mapper
        )
        {
            _customerContactRepository = customerContactRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerContactDto>> Handle(
            GetCustomerContactQuery request,
            CancellationToken cancellationToken
        )
        {
            // Query DB
            var customerContact = await _customerContactRepository.GetAsync();

            // convert data object to DTO
            var response = _mapper.Map<List<CustomerContactDto>>(customerContact);

            // return resonse
            return response;
        }
    }
}
