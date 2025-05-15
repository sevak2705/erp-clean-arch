using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Features.Contact.Commands;
using CleanArchitectureApp.Application.Interfaces;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Contact.Handlers
{
    public class UpdateCustomerContactCommandHandler(ICustomerContactRepository customerContactRepository, IMapper mapper) : IRequestHandler<UpdateCustomerContactCommand, Unit>
    {
        private readonly ICustomerContactRepository _customerContactRepository = customerContactRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(UpdateCustomerContactCommand request, CancellationToken cancellationToken)
        {
            //Fetch existing entity(or throw 404)
                    var entity = await _customerContactRepository.GetByIdAsync(request.Id)
                                 ?? throw new KeyNotFoundException($"CustomerContact with ID {request.Id} not found.");

            // 2️⃣ Apply mapped changes

            _mapper.Map(request, entity);
  

            // 3️⃣ Persist
            await _customerContactRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
