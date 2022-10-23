using Bazaar.DAL.Data;
using Bazaar.DAL.Models;
using Bazaar.DAL.Repository;
using Bazaar.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.DAL.Tests
{
    public class UnitOfWorkTests
    {
        private readonly DbContextOptions<BazaarDBContext> _options;
        private readonly int userId = 1;

        public UnitOfWorkTests()
        {

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .AddEntityFrameworkProxies()
                .BuildServiceProvider();

            _options = new DbContextOptionsBuilder<BazaarDBContext>()
                .UseInMemoryDatabase(databaseName: $"test_db_{Guid.NewGuid}")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            using var _bazaarDbContext = new BazaarDBContext(_options);

            _bazaarDbContext.User.Add
           (
               new User
               {
                   Id = 1,
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
            var user = await unitOfWork.UserRepository.GetById(1);
            Assert.Equal(userId, user.Id);
        }
    }
}
