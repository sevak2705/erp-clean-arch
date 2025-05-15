using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CleanArchitectureApp.Application.Features.Contact;
using CleanArchitectureApp.Application.Features.Contact.Commands;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.MappingProfiles
{
    public class CustomerContactProfile : AutoMapper.Profile
    {
        public CustomerContactProfile()
        {
             CreateMap<CustomerContact, CustomerContactDto>().ReverseMap();



            CreateMap<CreateCustomerContactCommand, CustomerContact>();
            // CreateMap<Application.DTOs.CustomerContactDto, Domain.Entities.CustomerContact>();
            // Add any additional mappings here


            CreateMap<UpdateCustomerContactCommand, CustomerContact>()
          .ForAllMembers(opt =>
             opt.Condition((src, dest, srcMember) => srcMember != null)
          );

        }
    }

}
