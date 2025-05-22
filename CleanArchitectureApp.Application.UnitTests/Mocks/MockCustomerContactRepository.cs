using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Domain.Entities;
using Moq;

namespace CleanArchitectureApp.Application.UnitTests.Mocks
{
    public class MockCustomerContactRepository
    {
        public static Mock<ICustomerContactRepository> GetCustomerContactMockRepository()
        {
            // Create a mock repository for ICustomerContactRepository
            var customerContacts = new List<Domain.Entities.CustomerContact>
            {
                new()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNo = 1234567890,
                },
                new()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    PhoneNo = 9876543210,
                },
            };
            var mockRepo = new Mock<ICustomerContactRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(customerContacts);

            mockRepo
                .Setup(r => r.CreateAsync(It.IsAny<CustomerContact>()))
                .Returns(
                    (CustomerContact customerContact) =>
                    {
                        customerContact.Id = customerContacts.Max(c => c.Id) + 1;
                        customerContacts.Add(customerContact);
                        return Task.CompletedTask;
                    }
                );
            return mockRepo;
        }
    }
}
