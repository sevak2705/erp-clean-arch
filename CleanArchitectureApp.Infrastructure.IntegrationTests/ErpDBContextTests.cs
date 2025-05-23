using CleanArchitectureApp.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace CleanArchitectureApp.Infrastructure.IntegrationTests
{
    public class ErpDatabaseContextTests
    {
        private readonly DbContextOptions<ErpDatabaseContext> _options;
        private readonly ErpDatabaseContext _context;
        public ErpDatabaseContextTests()
        {
            _options = new DbContextOptionsBuilder<ErpDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ErpDatabaseContext(_options);
        }
        // Add your test methods here
    
    
        [Fact]
        public void Save_SetDateCreatedValue()
        {
            // Arrange
            var entity = new Domain.Entities.CustomerContact
            {
                FirstName = "John",
                LastName = "Doe",
                CreatedDate = DateTime.Now,
                CreatedDateUtc = DateTime.UtcNow,
                CreatedBy = "TestUser",
                UpdatedBy = "TestUser"
            };
            _context.CustomerContacts.Add(entity);
    
            // Act
            _context.SaveChanges();
    
            // Assert
            //Assert.NotEqual(DateTime.MinValue, entity.CreatedDate);
            //Assert.NotEqual(DateTime.MinValue, entity.CreatedDateUtc);

            entity.CreatedDate.ShouldNotBe(DateTime.MinValue);
            entity.CreatedDateUtc.ShouldNotBe(DateTime.MinValue);

        }

        [Fact]
        public void Save_SetDateModifiedValue()
        {
            // Arrange
            var entity = new Domain.Entities.CustomerContact
            {
                FirstName = "John",
                LastName = "Doe",
                CreatedBy = "TestUser",
                UpdatedBy = "TestUser"
            };
            _context.CustomerContacts.Add(entity);
            _context.SaveChanges();
    
            // Act
            entity.FirstName = "Jane";
            _context.SaveChanges();
    
            // Assert
            entity.UpdatedDate.ShouldNotBe(DateTime.MinValue);
            entity.UpdatedDateUtc.ShouldNotBe(DateTime.MinValue);

        }
    }
}