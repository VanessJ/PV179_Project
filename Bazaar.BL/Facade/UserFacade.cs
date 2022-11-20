using Bazaar.BL.Dtos;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Review;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Services;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Services.Reactions;
using Bazaar.BL.Services.Reviews;
using Bazaar.BL.Services.Tags;
using Bazaar.BL.Services.Users;
using Bazaar.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Facade
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserService _userService;
        private readonly IReactionService _reactionService;
        private readonly IReviewService _reviewService;
        private readonly IUnitOfWork _unitOfWork;


        UserFacade(IUserService userUserService, IReactionService reactionService, IReviewService reviewService, IUnitOfWork unitOfWork)
        {
            _userService = userUserService;
            _reactionService = reactionService;
            _reviewService = reviewService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserListDto>> FilterUsers(UserFilterDto filterDto)
        {
            var users = await _userService.ExecuteQueryAsync(filterDto);
            return users;
        }

        public async Task EditUser(UserEditDto editDto)
        {
            await _userService.UpdateAsync<UserEditDto>(editDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task RegisterUser(UserCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task<UserProfileDetail> GetUserProfileDetail(Guid id)
        {
            var user = await _userService.GetByIdAsync<UserProfileDetail>(id);
            if (user == null)
            {
                throw new ArgumentException();
            }
            return user;
        }

        public async Task<UserDetailDto> GetUserDetail(Guid id)
        {
            var user = await _userService.GetByIdAsync<UserDetailDto>(id);
            if (user == null)
            {
                throw new ArgumentException();
            }
            return user;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsWrittenByUser(Guid id)
        {
            return await _userService.GetReviewsWrittenByUser(id);
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsOfUser(Guid id)
        {
            return await _userService.GetReviewsOfUser(id);
        }

        public async Task WriteReviewOfUser(ReviewCreateDto reviewDto)
        {
            await _reviewService.CreateAsync<ReviewCreateDto>(reviewDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task WriteReactionToAd(ReactionCreateDto reactionCreateDto)
        {
            await _reviewService.CreateAsync<ReactionCreateDto>(reactionCreateDto);
            await _unitOfWork.CommitAsync();
        }
    }
}
