using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Contact.Commands
{
    public class UpdateCustomerContactCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long? PhoneNo { get; set; }
    }
}
