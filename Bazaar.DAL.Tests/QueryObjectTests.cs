using System;
using System.Linq;
using System.Threading.Tasks;
using Bazaar.DAL.Data;
using Bazaar.DAL.Infrastructure.EFCore;
using Bazaar.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.Tests
{
    public class QueryObjectTests
    {
        private DbContextOptions<BazaarDBContext> _options;

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
        public async Task Where_OneValidPredicate_Filtered()
        {
            using var _bazaarDbContext = new BazaarDBContext(_options);
            var queryObject = new EFQuery<User>(_bazaarDbContext);
            queryObject.Filter(u => u.FirstName.Equals("Ferko"));

            var result = await queryObject.ExecuteAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Where_OneValidPredicateOrdered_FilteredOrdered()
        {
            using var _bazaarDbContext = new BazaarDBContext(_options);
            var queryObject = new EFQuery<Ad>(_bazaarDbContext);
            queryObject
                .Filter(a => !a.IsPremium)
                .OrderBy(x => x.Title);

            var result = await queryObject.ExecuteAsync();

            Assert.Equal(1, result.First().Id);
            Assert.Equal(3, result.Count());
            Assert.Equal("Predam svoju svokru!", result.Last().Title);
        }

        [Fact]
        public async Task Where_OneValidPredicateOrderedPaged_FilteredPagedOrdered()
        {
            using var _bazaarDbContext = new BazaarDBContext(_options);
            var queryObject = new EFQuery<Ad>(_bazaarDbContext);
            queryObject
                .Filter(x => x.IsValid)
                .Page(1, 2)
                .OrderBy(x => x.Description, false);

            var result = await queryObject.ExecuteAsync();

            Assert.Equal(2, result.Count());
            Assert.Equal(4, result.First().Id);
        }
    }
}