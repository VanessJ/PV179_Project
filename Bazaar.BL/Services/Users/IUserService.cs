using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Dtos;
using Bazaar.BL.QueryObjects;
using Bazaar.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
