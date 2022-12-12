using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Services.Tags;
using Bazaar.BL.Services.Users;
using Bazaar.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace Bazaar.BL.Facade
{
    public class AdminFacade : IAdminFacade
    {
        private readonly IUserService _userService;
        private readonly ITagService _tagService;
        private readonly IAdService _adService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminFacade(IUserService userUserService, ITagService tagService, IAdService adService, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _userService = userUserService;
            _tagService = tagService;
            _adService = adService;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task AddNewTag(TagCreateDto tagCreateDto)
        {
            await _tagService.CreateAsync<TagCreateDto>(tagCreateDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteTag(Guid id)
        {
            await _tagService.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAd(Guid id)
        {
            var adDeleteDto = await _adService.GetByIdAsync<AdDeleteDto>(id);
            adDeleteDto.IsValid = false;
            await _adService.UpdateAsync<AdDeleteDto>(adDeleteDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task EditTag(TagDto tagEditDto)
        {
            await _tagService.UpdateAsync<TagDto>(tagEditDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task BanUser(Guid id)
        {
            var userUpdateDto = await _userService.GetByIdAsync<UserUpdateDto>(id);
            userUpdateDto.Banned = true;
            await _userService.UpdateAsync<UserUpdateDto>(userUpdateDto);
            await _unitOfWork.CommitAsync();
        }
        public async Task UnBanUser(Guid id)
        {
            var userUpdateDto = await _userService.GetByIdAsync<UserUpdateDto>(id);
            userUpdateDto.Banned = false;
            await _userService.UpdateAsync<UserUpdateDto>(userUpdateDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpgradeUser(Guid id)
        {
            var result = await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(id.ToString()), "Admin");
            if (result.Succeeded)
            {
                var userUpdateDto = await _userService.GetByIdAsync<UserUpdateDto>(id);
                userUpdateDto.Level = 1;
                await _userService.UpdateAsync<UserUpdateDto>(userUpdateDto);
                await _unitOfWork.CommitAsync();
            }

            
        }
        public async Task DowngradeUser(Guid id)
        {
            var result = await _userManager.RemoveFromRoleAsync(await _userManager.FindByIdAsync(id.ToString()), "Admin");
            if (result.Succeeded)
            {
                var userUpdateDto = await _userService.GetByIdAsync<UserUpdateDto>(id);
                userUpdateDto.Level = 0;
                await _userService.UpdateAsync<UserUpdateDto>(userUpdateDto);
                await _unitOfWork.CommitAsync();
            }
        }


        public async Task<IEnumerable<UserListDto>> GetBannedUsers()
        {
           return await _userService.ExecuteQueryAsync(new UserFilterDto() { OnlyBanned = true });
        }
    }
}
