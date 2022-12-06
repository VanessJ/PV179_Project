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
        private IUserService _userService;
        private IMapper _mapper;
        public UserController(IAdminFacade adminFacade, IMapper mapper, IUserService userService)
        {
            _adminFacade = adminFacade;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new UserIndexViewModel()
            {
                Users = await _userService.GetAllAsync<UserListDto>()
            };
            return View(model);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var dto = await _userService.GetByIdAsync<UserProfileDetailDto>(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<UserDetailViewModel>(dto);
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
