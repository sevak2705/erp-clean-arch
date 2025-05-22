using AutoMapper;
using CleanArchitectureApp.Application.Features.Contact;
using CleanArchitectureApp.Application.Features.Contact.Handlers;
using CleanArchitectureApp.Application.Features.Contact.Queries;
using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Application.MappingProfiles;
using CleanArchitectureApp.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace CleanArchitectureApp.Application.UnitTests.Features.Contact.Queries
{
    public class GetCustomerContactQueryHandlerTests
    {
        private readonly Mock<ICustomerContactRepository> _mockRepo;
        private IMapper _mapper;

        public GetCustomerContactQueryHandlerTests()
        {
            // Arrange
            _mockRepo = MockCustomerContactRepository.GetCustomerContactMockRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerContactProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCustomerContactQueryHandler_ShouldReturnListOfCustomerContactDto()
        {
            // Arrange
            var handler = new GetCustomerContactQueryHandler(_mockRepo.Object, _mapper);
            var query = new GetCustomerContactQuery();
            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            // Assert

            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<CustomerContactDto>>();
            result.Count.ShouldBe(2);
            // Assuming there are 2 contacts in the mock repository
        }
    }
}
