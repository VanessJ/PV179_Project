using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Facade;
using Bazaar.BL.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Bazaar.App.Controllers
{
    public class UserController : Controller
    {
        private IAdminFacade _adminFacade;
        private IUserFacade _userFacade;
        private IMapper _mapper;
        private IAdFacade _adFacade;
        public UserController(IAdminFacade adminFacade, IMapper mapper, IUserFacade userFacade, IAdFacade adFacade)
        {
            _adminFacade = adminFacade;
            _mapper = mapper;
            _userFacade = userFacade;
            _adFacade = adFacade;
        }

        public async Task<IActionResult> Index()
        {
            var model = new UserIndexViewModel()
            {
                Users = await _userFacade.GetAllUsers()
            };
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var userDto = await _userFacade.GetUserProfileDetail(id);
            if (userDto == null)
            {
                return NotFound();
            }

            var userAdsDto = await _adFacade.GetOwnerAds(id);

            if (userAdsDto == null)
            {
                return NotFound();
            }

            userDto.Ads = userAdsDto;

            var model = _mapper.Map<UserDetailViewModel>(userDto);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ban(Guid id)
        {
            await _adminFacade.BanUser(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Unban(Guid id)
        {
            await _adminFacade.UnBanUser(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
