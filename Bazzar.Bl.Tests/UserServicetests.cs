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

namespace Bazzar.Bl.Tests
{
    public class UserServiceTests
    {
        private DbContextOptions<BazaarDBContext> _options;
        private readonly Guid userId1 = Guid.NewGuid();
        private readonly Guid userId2 = Guid.NewGuid();
        private readonly AutoMapper.MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Ad, AdCreateDto>().ReverseMap();
            cfg.CreateMap<Ad, AdDto>().ReverseMap();
            cfg.CreateMap<Ad, AdEditDto>().ReverseMap();
            cfg.CreateMap<Ad, AdListDto>().ReverseMap();

            cfg.CreateMap<Image, ImageCreateDto>().ReverseMap();
            cfg.CreateMap<Image, ImageDto>().ReverseMap();

            cfg.CreateMap<Reaction, ReactionCreateDto>().ReverseMap();
            cfg.CreateMap<Reaction, ReactionDto>().ReverseMap();

            cfg.CreateMap<Review, ReviewCreateDto>().ReverseMap();
            cfg.CreateMap<Review, ReviewDto>().ReverseMap();

            cfg.CreateMap<Tag, TagCreateDto>().ReverseMap();
            cfg.CreateMap<Tag, TagDto>().ReverseMap();
            cfg.CreateMap<Tag, TagListDto>().ReverseMap();

            cfg.CreateMap<User, UserCreateDto>().ReverseMap();
            cfg.CreateMap<User, UserDto>().ReverseMap();
            cfg.CreateMap<User, UserEditDto>().ReverseMap();
            cfg.CreateMap<User, UserListDto>().ReverseMap();
        });

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
        public async Task GetUserTest()
        {
            var context = new BazaarDBContext(_options);
            IUnitOfWork uow = new EFUnitOfWork(context);
            IQuery<User> query = new EFQuery<User>(context);

            Mapper mapper = new Mapper(config);
            UserQueryObject userQueryObject = new UserQueryObject(mapper, query);
            var userService = new UserService(uow, mapper, userQueryObject);
            
            var result = await userService.GetByIdAsync<UserDto>(userId1);
            var d = await userService.ExecuteQueryAsync(new UserFilterDto() { LikeUserName = "Test"});

            Assert.Equal(userId1, result.Id);
            Assert.Equal("TestUser1", result.UserName);
        }


        //random test na otestovanie mapping vztahov, potom to dam prec
        [Fact]
        public async Task Test2()
        {
            var context = new BazaarDBContext(_options);
            IUnitOfWork uow = new EFUnitOfWork(context);
            IQuery<User> query = new EFQuery<User>(context);

            Mapper mapper = new Mapper(config);
            IUserQueryObject userQueryObject = new UserQueryObject(mapper, query);
            var reviewService = new ReviewService(uow, mapper);

            var dto = new ReviewCreateDto() { Descritption = "Super muz", ReviewedId = userId1, ReviewerId = userId2, Score = 5};
            var review_id = await reviewService.CreateAsync<ReviewCreateDto>(dto);
            await uow.CommitAsync();

            var dto_test = await reviewService.GetByIdAsync<ReviewDto>(review_id, nameof(Review.Reviewer), nameof(Review.Reviewed));

            Assert.Equal(dto_test.Reviewed.UserName, "TestUser1");
        }

        [Fact]
        public async Task Test3()
        {
            



        }
    }
}
