using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Facade;
using Bazaar.BL.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;

namespace Bazaar.App.Controllers
{
    [Authorize]
    public class PremiumController : Controller
    {
        private IUserFacade _userFacade;
        public PremiumController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public IActionResult Index() 
        {
            return View();
        }

        public async Task<IActionResult> Buy()
        {
            string? id = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (id == null)
            {
                throw new AuthenticationException();
            }

            await _userFacade.SetAsPremium(new Guid(id));

            return Redirect("/Home/Index");
        }
    }
}
