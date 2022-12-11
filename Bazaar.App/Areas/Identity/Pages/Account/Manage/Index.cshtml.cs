// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Facade;
using Bazaar.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Authentication;
using System.Security.Claims;

namespace Bazaar.App.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserFacade _userFacade;
        private readonly IAdFacade _adFacade;

        [BindProperty]
        public Guid Id { get; set; }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }
        public IEnumerable<AdListDto> Ads { get; set; }

        public IEnumerable<ReactionDto> Reactions { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IUserFacade userFacade,
            IAdFacade adFacade)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userFacade = userFacade;
            _adFacade = adFacade;
        }

        private async Task LoadAsync(IdentityUser user)
        {

            Guid id = new Guid(user.Id);

            var userDto = await _userFacade.GetUserProfileDetail(id);

            var userAdsDto = await _adFacade.GetOwnerAds(id);

            userDto.Ads = userAdsDto;

            Id = userDto.Id;
            PhoneNumber = userDto.PhoneNumber;
            FirstName = userDto.FirstName;
            LastName = userDto.LastName;
            UserName = userDto.UserName;
            Ads = userDto.Ads;
            var reactions = userDto.Reactions;
            var detailReactions = new List<ReactionDto>();

            if (reactions != null)
            {
                foreach (var r in reactions)
                {
                    var detail = await _adFacade.ReactionDetail(r.Id);
                    if (detail != null)
                    {
                        detailReactions.Add(detail);
                    }
                }
            }
            Reactions = detailReactions;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
         

            await _userFacade.EditUserDetails(new UserEditDetailDto
            {
                Id = Id,
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
            });

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
