using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Entities
{
    public class CustomerContact : CommonEntity
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public long? PhoneNo { get; set; }
        public long? WhatsAppNo { get; set; }
        public bool Status { get; set; } = true; // Default to Active
        public bool IsPhoneVerified { get; set; } = false; // Default to Unverified

        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
