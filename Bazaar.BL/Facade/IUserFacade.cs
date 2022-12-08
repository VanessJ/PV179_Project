using Bazaar.BL.Dtos;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Review;
using Bazaar.BL.Dtos.User;

namespace Bazaar.BL.Facade
{
    public interface IUserFacade
    {
        Task<IEnumerable<UserListDto>> FilterUsers(UserFilterDto filterDto);
        Task EditUser(UserEditDto editDto);
        Task RegisterUser(UserCreateDto createDto);
        Task<IEnumerable<UserListDto>> GetAllUsers();
        Task<UserProfileDetailDto> GetUserProfileDetail(Guid id);
        Task<UserDetailDto> GetUserDetail(Guid id);
        Task<IEnumerable<ReviewDto>> GetReviewsWrittenByUser(Guid id);
        Task<IEnumerable<ReviewDto>> GetReviewsOfUser(Guid id);
        Task WriteReviewOfUser(ReviewCreateDto reviewDto);
        Task WriteReactionToAd(ReactionCreateDto reactionCreateDto);
    }
}
