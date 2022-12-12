using Bazaar.BL.Dtos;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Review;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Services.Reactions;
using Bazaar.BL.Services.Reviews;
using Bazaar.BL.Services.Users;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Repository;
using Bazaar.Infrastructure.UnitOfWork;

namespace Bazaar.BL.Facade
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserService _userService;
        private readonly IReviewService _reviewService;
        private readonly IReactionService _reactionService;
        private readonly IUnitOfWork _unitOfWork;


        public UserFacade(IUserService userUserService, IReviewService reviewService, IReactionService reactionService, IUnitOfWork unitOfWork)
        {
            _userService = userUserService;
            _reviewService = reviewService;
            _unitOfWork = unitOfWork;
            _reactionService = reactionService;
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

        public async Task EditUserDetails(UserEditDetailDto editDto)
        {
            await _userService.EditDetails(editDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task SetAsPremium(Guid id)
        {
            await _userService.SetAsPremium(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task RegisterUser(UserCreateDto createDto)
        {
            var user = await _userService.CreateAsync<UserCreateDto>(createDto);
            await _unitOfWork.CommitAsync();   
        }

        public async Task<IEnumerable<UserListDto>> GetAllUsers()
        {
            var user = await _userService.GetAllAsync<UserListDto>();
            if (user == null)
            {
                throw new ArgumentException();
            }
            return user;
        }

        public async Task<UserProfileDetailDto> GetUserProfileDetail(Guid id)
        {
            var user = await _userService.GetByIdAsync<UserProfileDetailDto>(id, nameof(User.Reactions));
            if (user == null)
            {
                throw new ArgumentException();
            }
            return user;
        }

        public async Task<UserDetailDto> GetUserDetail(Guid id)
        {
            var user = await _userService.GetByIdAsync<UserDetailDto>(id, nameof(User.Reactions));
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
            
            await _reactionService.SetReactionAsReviewed(reviewDto.ReactionId);
            await _reviewService.CreateAsync<ReviewCreateDto>(reviewDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task SetReactionAsReviewed(Guid id)
        {
            await _reactionService.SetReactionAsReviewed(id);
            await _unitOfWork.CommitAsync();
        }
        public async Task<ReviewDto> ReviewDetail(Guid id)
        {
            var review = await _reviewService.GetByIdAsync<ReviewDto>(id, nameof(Review.Reviewer), nameof(Review.Ad));
            if (review == null)
            {
                throw new EntityNotFoundException();
            }
            return review;

        }

        public async Task WriteReactionToAd(ReactionCreateDto reactionCreateDto)
        {
            await _reviewService.CreateAsync<ReactionCreateDto>(reactionCreateDto);
            await _unitOfWork.CommitAsync();
        }
    }
}
