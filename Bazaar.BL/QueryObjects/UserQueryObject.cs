﻿using Bazaar.Infrastructure.Query;
using Bazaar.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Dtos.User;
using AutoMapper;

namespace Bazaar.BL.QueryObjects
{
    public class UserQueryObject : BaseQueryObject<UserListDto, UserFilterDto, User, IQuery<User>>
    {
        public UserQueryObject(IMapper mapper, IQuery<User> query) : base(mapper, query) { }

        protected override IQuery<User> FilterByWhere(IQuery<User> query, UserFilterDto filter_dto)
        {
            if (!string.IsNullOrWhiteSpace(filter_dto.ContainsUserName))
            {
                return query.Filter(u => u.UserName.Equals(filter_dto.ContainsUserName));
            }
            else if (!string.IsNullOrWhiteSpace(filter_dto.LikeUserName))
            {
                return query.Filter(u => u.UserName.Contains(filter_dto.LikeUserName));
            }

            return query;
            
        }

    }
}