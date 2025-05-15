using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Contact.Queries
{
    public record GetCustomerContactByIdQuery(int Id) : IRequest<CustomerContactDto>;

}
