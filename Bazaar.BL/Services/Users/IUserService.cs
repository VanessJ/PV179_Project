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

namespace Bazaar.BL.Services.Users
{
    public interface IUserService
    {
        public Task<IEnumerable<UserListDto>> GetUserByNameAsync(string userName);
        public Task<IEnumerable<AdDto>> GetAdsOfUser(Guid id);

        public Task<IEnumerable<UserListDto>> ExecuteQueryAsync(UserFilterDto filterDto);
    }
}
