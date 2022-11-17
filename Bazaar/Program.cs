using Bazaar;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Facade;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

// Dependency Injection
// Call GetService<> if you want to get something
using var dependencies = new Dependencies();
var serviceProvider = dependencies.ServiceProvider;

var facade = serviceProvider.GetService<IAdFacade>();
var unitOfWork = serviceProvider.GetService<IUnitOfWork>();

// Get Courses
var userId = Guid.NewGuid();
var tagId = Guid.NewGuid();


unitOfWork.UserRepository.InsertAsync(new User
{
    Id = userId,
    UserName = "MISKO",
    FirstName = "MISKO",
    LastName = "Mrkvicka",
    Email = "jozko@gmailol.com",
    PhoneNumber = "0000000",
    PasswordHash = "tajneheslo"
});

unitOfWork.TagRepository.InsertAsync(new Tag()
{
    Id = tagId,
    TagName = "MISKOTAG"
});

await facade.AddNewAdAsync(userId, new List<ImageCreateDto>() {new ImageCreateDto() {Title = "HALO", Url = "path"}}, new List<Guid>(){ tagId }, new AdCreateDto() {Title = "Moj novy inzerat"});