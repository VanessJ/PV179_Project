using Azure;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Facade;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Services.Images;
using Bazaar.BL.Services.Reactions;
using Bazaar.BL.Services.Reviews;
using Bazaar.BL.Services.Tags;
using Bazaar.BL.Services.Users;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Bl.Tests
{
    public class FacadeTests
    {
        private Guid adId1 = Guid.NewGuid();
        private Guid adId2 = Guid.NewGuid();
        private Guid adId3 = Guid.NewGuid();
        private Guid userId = Guid.NewGuid();
        private Guid userId2 = Guid.NewGuid();
        private Guid userId3 = Guid.NewGuid();
        private AdListDto ad1;
        private AdListDto ad2;
        private AdListDto ad3;
        private UserListDto banned1;
        private UserListDto banned2;
        private List<AdListDto> adList;
        private List<UserListDto> bannedList;
        private UserProfileDetailDto userDetail;

        public FacadeTests()
        {
            ad1 = new AdListDto
            {
                Id = adId1,
                Title = "Predam psa",
                IsOffer = true,
                IsPremium = false,
                IsValid = true,
                Price = 100,
            };

            ad2 = new AdListDto
            {
                Id = adId2,
                Title = "Predam pyzamko",
                IsOffer = true,
                IsPremium = false,
                IsValid = true,
                Price = 300,
            };

            ad3 = new AdListDto
            {
                Id = adId2,
                Title = "Predam frajerku",
                IsOffer = true,
                IsPremium = false,
                IsValid = true,
                Price = 20,
            };

            adList = new List<AdListDto>() { ad1, ad2, ad3 };

            userDetail = new UserProfileDetailDto
            {
                Id = userId,
                UserName = "Ferko",
                FirstName = "Frantisek",
                LastName = "Velky",
                Email = "fero.velky@goo.com",
                PhoneNumber = "0911586444"     
            };

            banned1 = new UserListDto
            {
                Id = userId2,
                UserName = "Neslusne_meno",
                Banned = true
            };

            banned1 = new UserListDto
            {
                Id = userId2,
                UserName = "Neslusne_meno",
                Banned = true
            };

            banned1 = new UserListDto
            {
                Id = userId3,
                UserName = "Velmi_zly_chlapec",
                Banned = true
            };

            bannedList = new List<UserListDto>() { banned1, banned2 };

        }

        [Fact]
        public async Task AdFacadeReturnsCorrectResultOfQeuery()
        {
            var ImageServiceMockInstance = new Mock<IImageService>(MockBehavior.Loose).Object;
            var tagServiceMockInstance = new Mock<ITagService>(MockBehavior.Loose).Object;
            var reactionServiceMockInstance = new Mock<IReactionService>(MockBehavior.Loose).Object;
            var unitOfWorkInstance = new Mock<IUnitOfWork>(MockBehavior.Loose).Object;

            var adServiceMock = new Mock<IAdService>(MockBehavior.Loose);
            adServiceMock.Setup(x => x.ExecuteQueryAsync(It.IsAny<AdFilterDto>())).ReturnsAsync(adList);
            var adServiceMockInstance = adServiceMock.Object;

            IAdFacade adFacade = new AdFacade(adServiceMockInstance, tagServiceMockInstance, ImageServiceMockInstance, reactionServiceMockInstance, unitOfWorkInstance);
            var filtered_ads = await adFacade.FilterAds(new AdFilterDto() { OnlyOffer = true });
            Assert.Equal(3, filtered_ads.Count());
            Assert.Equal("Predam psa", filtered_ads.First().Title);
        }

        [Fact]
        public async Task UserFacadeReturnsCorrectUserDetail()
        {
            var ReviewServiceInstance = new Mock<IReviewService>(MockBehavior.Loose).Object;
            var unitOfWorkInstance = new Mock<IUnitOfWork>(MockBehavior.Loose).Object;

            var userService = new Mock<IUserService>(MockBehavior.Loose);
            userService.Setup(x => x.GetByIdAsync<UserProfileDetailDto>(It.IsAny<Guid>())).ReturnsAsync(userDetail);
            var userServiceInstance = userService.Object;

            IUserFacade userFacade = new UserFacade(userServiceInstance, ReviewServiceInstance, unitOfWorkInstance);
            var detail = await userFacade.GetUserProfileDetail(userId);
            Assert.Equal("Ferko", detail.UserName);
            Assert.Equal("Velky", detail.LastName);

        }

        [Fact]
        public async Task AdminFacadeReturnsBannedUsers()
        {
            var tagServiceMockInstance = new Mock<ITagService>(MockBehavior.Loose).Object;
            var adServiceInstance = new Mock<IAdService>(MockBehavior.Loose).Object;
            var unitOfWorkInstance = new Mock<IUnitOfWork>(MockBehavior.Loose).Object;

            var userService = new Mock<IUserService>(MockBehavior.Loose);
            
            userService.Setup(x => x.ExecuteQueryAsync(It.IsAny<UserFilterDto>())).ReturnsAsync(bannedList);
            var userServiceInstance = userService.Object;

            IAdminFacade adminFacade = new AdminFacade(userServiceInstance, tagServiceMockInstance, adServiceInstance, unitOfWorkInstance);
            var banned = await adminFacade.GetBannedUsers();
            Assert.Equal(2, banned.Count());
        }
    }
}
