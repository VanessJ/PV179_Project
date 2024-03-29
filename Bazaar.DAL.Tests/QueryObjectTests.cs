using System;
using System.Linq;
using System.Threading.Tasks;
using Bazaar.DAL.Data;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.EFCore.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.Tests
{
    public class QueryObjectTests
    {
        private DbContextOptions<BazaarDBContext> _options;
        private readonly Guid userId1 = Guid.NewGuid();
        private readonly Guid userId2 = Guid.NewGuid();
        private readonly Guid adId1 = Guid.NewGuid();
        private readonly Guid adId2 = Guid.NewGuid();
        private readonly Guid adId3 = Guid.NewGuid();
        private readonly Guid adId4 = Guid.NewGuid();
        private readonly Guid adId5 = Guid.NewGuid();
        public QueryObjectTests()
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
                }
             );
            _bazaarDbContext.User.Add
            (
                new User
                {
                    Id = userId2,
                    UserName = "TestUser2",
                    FirstName = "Ferko",
                    LastName = "Priezviskovy",
                    Email = "ferko@gmailol.com",
                    PhoneNumber = "2020040444"
                }
            );
            _bazaarDbContext.Ad.Add
            (
                new Ad
                {
                    Id = adId1,
                    Title = "Predam psa",
                    Description = "Je velmi zlata, zbavte ma jej, prosim",
                    IsOffer = true,
                    IsPremium = false,
                    IsValid = true,
                    Price = 100,
                    UserId = userId1
                }
            );
            _bazaarDbContext.Ad.Add
            (
                new Ad
                {
                    Id = adId2,
                    Title = "Predam macku",
                    Description = "Je velmi zlata, mam ich moc vela, dalsiu nechcem!",
                    IsOffer = true,
                    IsPremium = true,
                    IsValid = false,
                    Price = 100,
                    UserId = userId1
                }
            );
            _bazaarDbContext.Ad.Add
            (
                new Ad
                {
                    Id = adId3,
                    Title = "Predam strom",
                    Description = "je to velmi pekny strom!",
                    IsOffer = true,
                    IsPremium = false,
                    IsValid = false,
                    Price = 900,
                    UserId = userId1
                }
            );
            _bazaarDbContext.Ad.Add
            (
                new Ad
                {
                    Id = adId4,
                    Title = "HRABLE NA PREDAJ, VOLAJ IHNED!!!",
                    Description = "Multifunkcne hrable na solarny pohon!",
                    IsOffer = true,
                    IsPremium = true,
                    IsValid = true,
                    Price = 111,
                    UserId = userId2
                }
            );
            _bazaarDbContext.Ad.Add
            (
                new Ad
                {
                    Id = adId5,
                    Title = "Predam svoju svokru!",
                    Description = "Kto chce mat doma svokru..",
                    IsOffer = true,
                    IsPremium = false,
                    IsValid = false,
                    Price = 0,
                    UserId = userId2
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
                .OrderBy("Title");

            var result = await queryObject.ExecuteAsync();

            Assert.Equal(adId1, result.First().Id);
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
                .OrderBy("Description", false);

            var result = await queryObject.ExecuteAsync();

            Assert.Equal(2, result.Count());
            Assert.Equal(adId4, result.First().Id);
        }
    }
}