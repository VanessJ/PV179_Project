using AutoMapper;
using Bazaar.BL.Dtos;
using Bazaar.BL.Services;
using Bazaar.DAL.Data;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.EFCore.UnitOfWork;
using Bazaar.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Bl.Tests
{
    public class UserServiceTests
    {
        private DbContextOptions<BazaarDBContext> _options;


        public UserServiceTests()
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
            _bazaarDbContext.User.Add
            (
                new User
                {
                    Id = 2,
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
            var context = new BazaarDBContext(_options);
            IUnitOfWork uow = new EFUnitOfWork(context);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDto>().ReverseMap();
            });

            Mapper mapper = new Mapper(config);


            var userService = new UserService(uow, mapper);
            var result = await userService.GetByIdAsync<UserDto>(1);

            Assert.Equal(1, result.Id);
            Assert.Equal("TestUser1", result.UserName);
        }
    }
}
