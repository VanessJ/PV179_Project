using AutoMapper;
using Bazaar.DAL.Models;
using Bazaar.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Base;
using Bazaar.Infrastructure.Query;
using Bazaar.BL.Dtos.User;

namespace Bazaar.BL.Config
{
    public class BussinessMapperConfig
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserDto>().ReverseMap();
            config.CreateMap<IEnumerable<User>, QueryResultDto<UserListDto>>().ReverseMap();
        }
    }
}
