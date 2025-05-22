using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureApp.Application.Interfaces;
using FluentValidation;

namespace CleanArchitectureApp.Application.Features.Contact.Commands
{
    public class UpdateCustomerContactCommandValidator
        : AbstractValidator<UpdateCustomerContactCommand>
    {
        public UpdateCustomerContactCommandValidator(ICustomerContactRepository repo)
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid contact ID.");

            // only run this rule if PhoneNo has a value
            RuleFor(x => x.PhoneNo!.Value) // the `!` tells the compiler "I know PhoneNo isn't null here"
                .InclusiveBetween(6000000000L, 9999999999L)
                .WithMessage("Phone number must be 10 digits starting with 6–9.")
                .MustAsync(
                    async (cmd, phone, ct) =>
                    {
                        var existing = await repo.GetContactByPhoneAsync(phone);
                        return existing == null || existing.Id == cmd.Id;
                    }
                )
                .WithMessage("Phone number is already in use.")
                .When(x => x.PhoneNo.HasValue); // skip the rule entirely if PhoneNo is null
        }
    }
}
