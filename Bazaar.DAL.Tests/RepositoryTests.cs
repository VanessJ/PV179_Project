﻿using Bazaar.DAL.Data;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Bazaar.Infrastructure.EFCore.Tests
{
    public class RepositoryTests
    {
        private readonly DbContextOptions<BazaarDBContext> _options;

        private readonly Guid testUser2Id = Guid.NewGuid();
        private static readonly Guid testUser3Id = Guid.NewGuid();

        private readonly User newUser = new()
        {
            Id = testUser3Id,
            UserName = "TestUser3",
            FirstName = "Anicka",
            LastName = "Mrkvicka",
            Email = "anicka@gmailol.com",
            PhoneNumber = "0000000"
        };


        public RepositoryTests()
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
                    Id = Guid.NewGuid(),
                    UserName = "TestUser1",
                    FirstName = "Ferko",
                    LastName = "Mrkvicka",
                    Email = "jozko@gmailol.com",
                    PhoneNumber = "0000000",
                }
             );
            _bazaarDbContext.User.Add
            (
                new User
                {
                    Id = testUser2Id,
                    UserName = "TestUser2",
                    FirstName = "Ferko",
                    LastName = "Priezviskovy",
                    Email = "ferko@gmailol.com",
                    PhoneNumber = "2020040444"
                }
            );
            
            _bazaarDbContext.SaveChanges();
        }

        [Fact]
        public async Task GetById_NonExistingUserId_ReturnNull()
        {
            using BazaarDBContext _bazaarDbContext = new BazaarDBContext(_options);
            var userRepository = new EFGenericRepository<User>(_bazaarDbContext);
            var user = await userRepository.GetByIdAsync(testUser3Id);
            Assert.Null(user);
        }

        [Fact]
        public async Task GetById_ExistingUserId_ReturnCorrectId()
        {
            using BazaarDBContext _bazaarDbContext = new BazaarDBContext(_options);
            var userRepository = new EFGenericRepository<User>(_bazaarDbContext);
            var user = await userRepository.GetByIdAsync(testUser2Id);
            Assert.Equal(testUser2Id, user.Id);
        }

        [Fact]
        public async Task Delete_ExistingUser_ReturnNull()
        {
            using BazaarDBContext _bazaarDbContext = new BazaarDBContext(_options);
            var userRepository = new EFGenericRepository<User>(_bazaarDbContext);
            await userRepository.DeleteAsync(testUser2Id);
            await userRepository.SaveAsync();
            var deletedUser = await userRepository.GetByIdAsync(testUser2Id);
            Assert.Null(deletedUser);
        }

        [Fact]
        public async Task Create_NewUser_ReturnTheSameUser()
        {
            using BazaarDBContext _bazaarDbContext = new BazaarDBContext(_options);
            var userRepository = new EFGenericRepository<User>(_bazaarDbContext);
            await userRepository.InsertAsync(newUser);
            await userRepository.SaveAsync();
            var insertedUser = await userRepository.GetByIdAsync(newUser.Id);
            Assert.Equal(newUser, insertedUser);
        }

        [Fact]
        public async Task Update_ExistingUserFistName_ReturnUpdatedName()
        {
            using BazaarDBContext _bazaarDbContext = new BazaarDBContext(_options);
            var userRepository = new EFGenericRepository<User>(_bazaarDbContext);
            var editedUser = await userRepository.GetByIdAsync(testUser2Id);
            editedUser.FirstName = "Ferdinand";
            userRepository.Update(editedUser);
            await userRepository.SaveAsync();
            editedUser = await userRepository.GetByIdAsync(testUser2Id);
            Assert.Equal("Ferdinand", editedUser.FirstName);
        }







    }
}
