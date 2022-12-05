using Bazaar.BL.Dtos.User;
using Bazaar.BL.Services.CRUDServices;
using Bazaar.BL.Dtos.Review;

namespace Bazaar.BL.Services.Users
{
    public interface IUserService : ICRUDService
    {
        Task<IEnumerable<UserListDto>> ExecuteQueryAsync(UserFilterDto filterDto);

        Task<IEnumerable<ReviewDto>> GetReviewsOfUser(Guid id);

        Task<IEnumerable<ReviewDto>> GetReviewsWrittenByUser(Guid id);

        Task<bool> IsUsernameTaken(string username);

    }
}
