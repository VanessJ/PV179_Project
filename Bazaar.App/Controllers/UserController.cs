using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Review;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Facade;
using Bazaar.BL.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optional;
using System.Security.Authentication;
using System.Security.Claims;

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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(new UserIndexViewModel() { Users = await _userFacade.GetAllUsers() });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserIndexViewModel model)
        {
            var filter = new UserFilterDto();
            filter.LikeUserName = OptionExtensions.SomeNotNull(model.UserName!);
            filter.Level = model.Level.ToOption();
            if (model.Banned == true)
            {
                filter.OnlyBanned = true;
            }
            if (model.Banned == false)
            {
                filter.OnlyNotBanned = true;
            }

            model.Users = await _userFacade.FilterUsers(filter);

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

            var reviewsDetails = new List<ReviewDto>();
            var reviews = await _userFacade.GetReviewsOfUser(id);
            if (reviews != null)
            {
                foreach (var r in reviews)
                {
                    var detail = await _userFacade.ReviewDetail(r.Id);
                    if (detail != null)
                    {
                        reviewsDetails.Add(detail);
                    }
                }

            }
            var model = _mapper.Map<UserDetailViewModel>(userDto);
            model.Reviews = reviewsDetails;
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ban(Guid id)
        {
            await _adminFacade.BanUser(id);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Unban(Guid id)
        {
            await _adminFacade.UnBanUser(id);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upgrade(Guid id)
        {
            await _adminFacade.UpgradeUser(id);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Downgrade(Guid id)
        {
            await _adminFacade.DowngradeUser(id);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> AddReview(Guid adId, Guid reactionId)
        {
            var ad = await _adFacade.AdDetail(adId);
            if (ad == null)
            {
                return NotFound($"Unable to load ad '{adId}'.");
            }

            string? idStr = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (idStr == null)
            {
                throw new AuthenticationException();
            }

            Guid currentUserId = new Guid(idStr);

            var model = new ReviewCreateViewModel
            {
                AdId = adId,
                ReviewerId = currentUserId,
                ReviewedId = ad.Creator.Id,
                ReactionId = reactionId     
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(ReviewCreateViewModel model)
        {
            var review = model;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = _mapper.Map<ReviewCreateDto>(model);
            await _userFacade.WriteReviewOfUser(dto);

            return RedirectToAction("Details", new { id = model.ReviewedId });
        }


    }
}
