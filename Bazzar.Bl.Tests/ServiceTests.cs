using AutoMapper;
using Bazaar.BL.Dtos;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Review;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Services;
using Bazaar.BL.Services.Reviews;
using Bazaar.DAL.Data;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.EFCore.Query;
using Bazaar.Infrastructure.EFCore.UnitOfWork;
using Bazaar.Infrastructure.Query;
using Bazaar.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using BazaarDI;
using System;
using Bazaar.BL.QueryObjects.Users;
using Optional;
using Optional;
using BazaarDI;
using System;
using Bazaar.BL.QueryObjects.Users;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.QueryObjects.Ads;
using Bazaar.BL.Services.Reactions;
using Bazaar.BL.QueryObjects.Tags;
using Bazaar.BL.Services.Tags;

namespace Bazzar.Bl.Tests
{
    public class ServiceTests
    {
        private DbContextOptions<BazaarDBContext> _options;
        private readonly Guid userId1 = Guid.NewGuid();
        private readonly Guid userId2 = Guid.NewGuid();
        private readonly Guid adId1 = Guid.NewGuid();
        private readonly Guid adId2 = Guid.NewGuid();
        private readonly Guid tagId1 = Guid.NewGuid();
        private readonly Guid tagId2 = Guid.NewGuid();
        private readonly Guid reactionId = Guid.NewGuid();
        private readonly IMapper mapper = new Mapper(new MapperConfiguration(Bazaar.BL.Config.BusinessMapperConfig.ConfigureMapping));

        public ServiceTests()
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
                    UserName = "ATestUser2",
                    FirstName = "AFerko",
                    LastName = "Priezviskovy",
                    Email = "ferko@gmailol.com",
                    PhoneNumber = "2020040444",
                    PasswordHash = "supertajneheslo"
                }
            );

            var nepotrebneTag = new Tag
            {
                Id = tagId1,
                TagName = "Nepotrebne"
            };

            var pesTag = new Tag
            {
                Id = tagId2,
                TagName = "Pes"
            };

            _bazaarDbContext.Tag.Add
           (
               pesTag
           );

            _bazaarDbContext.Tag.Add
            (
                nepotrebneTag
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
                   UserId = userId1,
                   Tags = new List<Tag>()

                    {
                        pesTag, nepotrebneTag
                   }
               }
           );

            _bazaarDbContext.Ad.Add
(
           new Ad
           {
               Id = adId2,
               Title = "Bla bla",
               Description = "Bli bli bli",
               IsOffer = true,
               IsPremium = false,
               IsValid = true,
               Price = 100,
               UserId = userId1,
               Tags = new List<Tag>()

                    {
                        pesTag
                   }
           }
        );

            _bazaarDbContext.Reaction.Add
            (
               new Reaction
               {
                   Id = reactionId,
                   AdId = adId1,
                   Message = "Chcem tohoto super psa",
                   Accepted = false,
                   UserId = userId1
               }
            );

            _bazaarDbContext.SaveChanges();
        }


        [Fact]
        public async Task GetUserReturnsCorrectUserName()
        {
            var context = new BazaarDBContext(_options);
            IUnitOfWork uow = new EFUnitOfWork(context);
            IQuery<User> query = new EFQuery<User>(context);
            UserQueryObject userQueryObject = new UserQueryObject(mapper, query);
            var userService = new UserService(uow, mapper, userQueryObject);
            

            var result = await userService.GetByIdAsync<UserDto>(userId1);
            var d = await userService.ExecuteQueryAsync(new UserFilterDto() { LikeUserName = "Test".Some()});

            Assert.Equal(userId1, result.Id);
            Assert.Equal("TestUser1", result.UserName);
        }


        [Fact]
        public async Task ReviewCreatedCreatorCorrectlyMapped()
        {
            var context = new BazaarDBContext(_options);
            IUnitOfWork uow = new EFUnitOfWork(context);
            IQuery<User> query = new EFQuery<User>(context);
            var reviewService = new ReviewService(uow, mapper);

            var dto = new ReviewCreateDto() { Descritption = "Super muz", ReviewedId = userId1, ReviewerId = userId2, Score = 5};
            var review_id = await reviewService.CreateAsync<ReviewCreateDto>(dto);
            await uow.CommitAsync();

            var dto_test = await reviewService.GetByIdAsync<ReviewDto>(review_id, nameof(Review.Reviewer), nameof(Review.Reviewed));

            Assert.Equal("TestUser1", dto_test.Reviewed.UserName);
        }


        [Fact]
        public async Task SetAdAsInvalidSetsAdAsInvalid()
        {
            var context = new BazaarDBContext(_options);
            IUnitOfWork uow = new EFUnitOfWork(context);
            IQuery<Ad> query = new EFQuery<Ad>(context);
            IAdQueryObject adQueryObject = new AdQueryObject(mapper, query);
            var ad_service = new AdService(uow, mapper, adQueryObject);

            await ad_service.SetAdAsInvalid(adId1);
            var ad = await ad_service.GetByIdAsync<AdDto>(adId1);

            Assert.False(ad.IsValid);
        }

        [Fact]
        public async Task GetByIdAfterDeleteAdReturnsNull()
        {
            var context = new BazaarDBContext(_options);
            IUnitOfWork uow = new EFUnitOfWork(context);
            IQuery<Ad> query = new EFQuery<Ad>(context);
            IAdQueryObject adQueryObject = new AdQueryObject(mapper, query);
            var ad_service = new AdService(uow, mapper, adQueryObject);

            await ad_service.DeleteAsync(adId1);
            await uow.CommitAsync();
            var ad = await ad_service.GetByIdAsync<AdDto>(adId1);

            Assert.Null(ad);
        }

        [Fact]
        public async Task ServiceExecutesQueryGetsCorrectResult()
        {
            var context = new BazaarDBContext(_options);
            IUnitOfWork uow = new EFUnitOfWork(context);
            IQuery<User> query = new EFQuery<User>(context);
            IUserQueryObject userQueryObject= new UserQueryObject(mapper, query);
            var tagService = new UserService(uow, mapper, userQueryObject);

            var user_filter_dto = new UserFilterDto { LikeUserName = "TestUser".Some(), OderCriteria = "UserName".Some() };
            var ads = await tagService.ExecuteQueryAsync(user_filter_dto);


            Assert.Equal(2, ads.Count());
            Assert.Equal("ATestUser2", ads.First().UserName);
        }






    }
}
