using Bazaar.DAL.Data;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Bazaar.DAL.Tests
{
    public class UnitOfWorkTests
    {
        private readonly DbContextOptions<BazaarDBContext> _options;
        private readonly Guid userId = Guid.NewGuid();

        public UnitOfWorkTests()
        {

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .AddEntityFrameworkProxies()
                .BuildServiceProvider();

            _options = new DbContextOptionsBuilder<BazaarDBContext>()
                .UseInMemoryDatabase(databaseName: $"test_db_{Guid.NewGuid()}")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            using var _bazaarDbContext = new BazaarDBContext(_options);

            _bazaarDbContext.User.Add
           (
               new User
               {
                   Id = userId,
                   UserName = "TestUser1",
                   FirstName = "Ferko",
                   LastName = "Mrkvicka",
                   Email = "jozko@gmailol.com",
                   PhoneNumber = "0000000",
                   PasswordHash = "tajneheslo"
               }
            );

            _bazaarDbContext.SaveChanges();

        }

        [Fact]
        public async Task GetById_ExistingUserId_ReturnCorrectId()
        {
            using BazaarDBContext _bazaarDbContext = new BazaarDBContext(_options);
            var unitOfWork = new EFUnitOfWork(_bazaarDbContext);
            var user = await unitOfWork.GetRepository<User>().GetByIdAsync(userId);
            Assert.Equal(userId, user.Id);
        }
    }
}
