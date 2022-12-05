using BazaarDI;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Facade;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Bazaar.Infrastructure.Query;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Services.Reviews;
using Bazaar.Infrastructure.EFCore.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Bazaar.DAL.Data;
using Bazaar.BL.Dtos;
using Bazaar.BL.Services;
using Bazaar.BL.Services.Users;
using Bazaar.BL.QueryObjects.Users;

using var dependencies = new Dependencies();
var serviceProvider = dependencies.ServiceProvider;

var db = serviceProvider.GetService<BazaarDBContext>();
var mapper = serviceProvider.GetService<IMapper>();
var query = serviceProvider.GetService<IQuery<Ad>>();
var unitOfWork = serviceProvider.GetService<IUnitOfWork>();
var queryObject = serviceProvider.GetService<IUserQueryObject>();
var service = serviceProvider.GetService<IUserService>();
var facade = serviceProvider.GetService<IAdFacade>();

var user = mapper.Map<User>(new UserDto { Id = Guid.NewGuid(), UserName = "Fero" });

// Get Courses
var userId = Guid.NewGuid();
var tagId = Guid.NewGuid();




await unitOfWork.UserRepository.InsertAsync(new User
{
    Id = userId,
    UserName = "MISKO",
    FirstName = "MISKO",
    LastName = "Mrkvicka",
    Email = "jozko@gmailol.com",
    PhoneNumber = "0000000",
    PasswordHash = "tajneheslo"
});

await unitOfWork.TagRepository.InsertAsync(new Tag()
{
    Id = tagId,
    TagName = "MISKOTAG"
});

await unitOfWork.CommitAsync();

await facade.AddNewAdAsync(userId, new List<ImageCreateDto>() { new ImageCreateDto() { Title = "HALO", Url = "path" } }, new List<Guid>() { tagId }, new AdCreateDto() { Title = "Moj novy inzerat" });
