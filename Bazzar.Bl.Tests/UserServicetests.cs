using AutoMapper;
using Bazaar.BL.Dtos;
using Bazaar.BL.QueryObjects;
using Bazaar.BL.Services;
using Bazaar.DAL.Data;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.EFCore.UnitOfWork;
using Bazaar.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bazzar.Bl.Tests
{
    public class UserServiceTests
    {
        private DbContextOptions<BazaarDBContext> _options;
        private readonly Guid userId1 = Guid.NewGuid();
        private readonly Guid userId2 = Guid.NewGuid();

        public UserServiceTests()
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
                    Id = userId1,
                    UserName = "TestUser1",
                    FirstName = "Ferko",
                    LastName = "Mrkvicka",
                    Email = "jozko@gmailol.com",
                    PhoneNumber = "0000000",
                    PasswordHash = "tajneheslo"
                }
             );
            _bazaarDbContext.User.Add
            (
                new User
                {
                    Id = userId2,
                    UserName = "TestUser2",
                    FirstName = "AFerko",
                    LastName = "Priezviskovy",
                    Email = "ferko@gmailol.com",
                    PhoneNumber = "2020040444",
                    PasswordHash = "supertajneheslo"
                }
            );
            
            _bazaarDbContext.SaveChanges();
        }

        [Fact]
        public async Task GetUserDto_ReturnsCorrectUserDto()
        {
            //var context = new BazaarDBContext(_options);
            //IUnitOfWork uow = new EFUnitOfWork(context);
            //UserQueryObject userQueryObject = new UserQueryObject();

            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<User, UserDto>().ReverseMap();
            //});

            //Mapper mapper = new Mapper(config);


            //var userService = new UserService(uow, mapper);
            //var result = await userService.GetByIdAsync<UserDto>(userId1);

            //Assert.Equal(userId1, result.Id);
            //Assert.Equal("TestUser1", result.UserName);
        }
    }
}
