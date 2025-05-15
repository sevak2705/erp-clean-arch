using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureApp.Infrastructure.Repositories
{
    public class CustomerContactRepository : GenericRepository<CustomerContact>, ICustomerContactRepository
    {
        public CustomerContactRepository(ErpDatabaseContext context) : base(context)
        {

        }

        public async Task<CustomerContact> GetContactByPhoneAsync(long phoneNo)
        {
            var res = await _context.CustomerContacts.FirstOrDefaultAsync(a => a.PhoneNo == phoneNo);
            if (res == null)
            {
                return new CustomerContact
                {
                    FirstName = string.Empty // Set the required property to avoid CS9035
                };
            }
            else
            {
                return res;
            }
        }
    }
}
