using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazaar.BL.Dtos.Base;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Dtos;
using Bazaar.DAL.Data;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.EFCore.Query;
using Bazaar.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bazaar.BL.QueryObjects;

namespace Bazzar.Bl.Tests
{
    public class QueryObjectTests
    {
        private DbContextOptions<BazaarDBContext> _options;

        private UserFilterDto user_filter_dto = new UserFilterDto { UserName = "Ferko" };
        public QueryObjectTests()
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
            _bazaarDbContext.Ad.Add
            (
                new Ad
                {
                    Id = 1,
                    Title = "Predam psa",
                    Description = "Je velmi zlata, zbavte ma jej, prosim",
                    IsOffer = true,
                    IsPremium = false,
                    IsValid = true,
                    Price = 100,
                    UserId = 1
                }
            );
            _bazaarDbContext.Ad.Add
            (
                new Ad
                {
                    Id = 2,
                    Title = "Predam macku",
                    Description = "Je velmi zlata, mam ich moc vela, dalsiu nechcem!",
                    IsOffer = true,
                    IsPremium = true,
                    IsValid = false,
                    Price = 100,
                    UserId = 1
                }
            );
            _bazaarDbContext.Ad.Add
            (
                new Ad
                {
                    Id = 3,
                    Title = "Predam strom",
                    Description = "je to velmi pekny strom!",
                    IsOffer = true,
                    IsPremium = false,
                    IsValid = false,
                    Price = 900,
                    UserId = 1
                }
            );
            _bazaarDbContext.Ad.Add
            (
                new Ad
                {
                    Id = 4,
                    Title = "HRABLE NA PREDAJ, VOLAJ IHNED!!!",
                    Description = "Multifunkcne hrable na solarny pohon!",
                    IsOffer = true,
                    IsPremium = true,
                    IsValid = true,
                    Price = 111,
                    UserId = 2
                }
            );
            _bazaarDbContext.Ad.Add
            (
                new Ad
                {
                    Id = 5,
                    Title = "Predam svoju svokru!",
                    Description = "Kto chce mat doma svokru..",
                    IsOffer = true,
                    IsPremium = false,
                    IsValid = false,
                    Price = 0,
                    UserId = 2
                }
            );
            _bazaarDbContext.SaveChanges();
        }

        [Fact]
        public async Task QueryObjectTest()
        {
            using var _bazaarDbContext = new BazaarDBContext(_options);
            var query = new EFQuery<User>(_bazaarDbContext);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<IEnumerable<User>, QueryResultDto<UserListDto>>().ReverseMap();
            });

            Mapper mapper = new Mapper(config);
            var userQueryObject = new UserQueryObject(mapper, query);
            var result = await userQueryObject.ExecuteQueryAsync(user_filter_dto);

            Assert.Equal(2, result.Items.Count());
        }
    }
}