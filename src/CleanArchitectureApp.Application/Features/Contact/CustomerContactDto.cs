using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Contact
{
    public class CustomerContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public long? PhoneNo { get; set; }
        public long? WhatsAppNo { get; set; }
        public bool Status { get; set; } = true; // Default to Active
        public bool IsPhoneVerified { get; set; } = false; // Default to Unverified

        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
