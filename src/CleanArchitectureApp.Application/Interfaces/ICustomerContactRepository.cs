using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Interfaces
{
    public interface ICustomerContactRepository
        : IGenericRepository<Domain.Entities.CustomerContact>
    {
        // Add any additional methods specific to CustomerContact if needed
        // For example:
        // Task<IEnumerable<CustomerContact>> GetContactsByStatusAsync(bool status);
        Task<CustomerContact> GetContactByPhoneAsync(long phoneNo);
    }
}
