using Bazaar.DAL.Data;
using Bazaar.DAL.Infrastructure.EFCore;
using Bazaar.DAL.Models;
using Bazaar.DAL.Repository;
using Bazaar.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.Infrastructure.EFCore.Tests
{
    public class UserRepositoryTests
    {
        private DbContextOptions<BazaarDBContext> _options;

        private readonly int testUser2Id = 2;

        private readonly User newUser = new()
        {
            Id = 3,
            UserName = "TestUser3",
            FirstName = "Anicka",
            LastName = "Mrkvicka",
            Email = "anicka@gmailol.com",
            PhoneNumber = "0000000",
            PasswordHash = "najtajnejsie heslo"
        };


        public UserRepositoryTests()
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
                    FirstName = "Ferko",
                    LastName = "Priezviskovy",
                    Email = "ferko@gmailol.com",
                    PhoneNumber = "2020040444",
                    PasswordHash = "supertajneheslo"
                }
            );
            
            _bazaarDbContext.SaveChanges();
        }

        [Fact]
        public async Task GetById_ExistingUserId_ReturnCorrectId()
        {
            using BazaarDBContext _bazaarDbContext = new BazaarDBContext(_options);
            var userRepository = new GenericRepository<User>(_bazaarDbContext);
            var user = await userRepository.GetById(testUser2Id);
            Assert.Equal(testUser2Id, user.Id);
        }

        [Fact]
        public async Task Delete_ExistingUser_ReturnNull()
        {
            using BazaarDBContext _bazaarDbContext = new BazaarDBContext(_options);
            var userRepository = new GenericRepository<User>(_bazaarDbContext);
            await userRepository.Delete(testUser2Id);
            await userRepository.Save();
            var deletedUser = await userRepository.GetById(testUser2Id);
            Assert.True(deletedUser == null);
        }

        [Fact]
        public async Task Create_NewUser_ReturnTheSameUser()
        {
            using BazaarDBContext _bazaarDbContext = new BazaarDBContext(_options);
            var userRepository = new GenericRepository<User>(_bazaarDbContext);
            await userRepository.Insert(newUser);
            await userRepository.Save();
            var insertedUser = await userRepository.GetById(newUser.Id);
            Assert.Equal(newUser, insertedUser);
        }

        [Fact]
        public async Task Update_ExistingUserFistName_ReturnUpdatedName()
        {
            using BazaarDBContext _bazaarDbContext = new BazaarDBContext(_options);
            var userRepository = new GenericRepository<User>(_bazaarDbContext);
            var editedUser = await userRepository.GetById(testUser2Id);
            editedUser.FirstName = "Ferdinand";
            userRepository.Update(editedUser);
            await userRepository.Save();
            editedUser = await userRepository.GetById(testUser2Id);
            Assert.True(editedUser.FirstName == "Ferdinand");

        }







    }
}
