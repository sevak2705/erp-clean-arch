using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitectureApp.Application.Features.Contact.Commands
{
    public class CreateCustomerContactCommandValidator
        : AbstractValidator<CreateCustomerContactCommand>
    {
        public CreateCustomerContactCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(20)
                .WithMessage("{PropertyName} must be less than 20 character")
                .MinimumLength(3)
                .WithMessage("{PropertyName} must be more than 3 character");

            RuleFor(x => x.PhoneNo)
                .InclusiveBetween(6_000_000_000L, 9_999_999_999L)
                .WithMessage("Phone number must be a 10-digit number starting with 6-9.");
        }
    }
}
