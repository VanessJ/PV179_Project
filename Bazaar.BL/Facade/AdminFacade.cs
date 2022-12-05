using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Services.Tags;
using Bazaar.BL.Services.Users;
using Bazaar.Infrastructure.UnitOfWork;
using Optional;

namespace Bazaar.BL.Facade
{
    public class AdminFacade : IAdminFacade
    {
        private readonly IUserService _userService;
        private readonly ITagService _tagService;
        private readonly IAdService _adService;
        private readonly IUnitOfWork _unitOfWork;

        public AdminFacade(IUserService userUserService, ITagService tagService, IAdService adService, IUnitOfWork unitOfWork)
        {
            _userService = userUserService;
            _tagService = tagService;
            _adService = adService;
            _unitOfWork = unitOfWork;
        }
        public async Task AddNewTag(TagCreateDto tagCreateDto)
        {
            await _userService.CreateAsync<TagCreateDto>(tagCreateDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task BanUserById(Guid id)
        {
            var userBanDto = new UserBanByIdDto()
            {
                UserId = id,
                Banned = true
            };
            await _userService.UpdateAsync(userBanDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task BanUserByUserName(string userName)
        {
            var userBanDto = await _userService.ExecuteQueryAsync(new UserFilterDto() {ContainsUserName = userName.Some()});
            userBanDto.First().Banned = true;
            await _userService.UpdateAsync(userBanDto.First());
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
            await _adService.UpdateAsync(adDeleteDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task EditTag(TagEditDto tagEditDto)
        {
            await _tagService.UpdateAsync<TagEditDto>(tagEditDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task UnBanUserById(Guid id)
        {
            var userBanDto = new UserBanByIdDto()
            {
                UserId = id,
                Banned = false
            };
            await _userService.UpdateAsync(userBanDto);
            await _unitOfWork.CommitAsync();
        }
        public async Task UnBanUserByUserName(string userName)
        {
            var userBanDto = await _userService.ExecuteQueryAsync(new UserFilterDto() { ContainsUserName = userName.Some() });
            userBanDto.First().Banned = false;
            await _userService.UpdateAsync(userBanDto.First());
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<UserListDto>> GetBannedUsers()
        {
           return await _userService.ExecuteQueryAsync(new UserFilterDto() { OnlyBanned = true });
        }
    }
}
