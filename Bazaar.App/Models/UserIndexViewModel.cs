﻿using Bazaar.BL.Dtos.User;

namespace Bazaar.App.Models
{
    public class UserIndexViewModel
    {
        public string? UserName { get; set; } = null;
        public int? Level { get; set; } = null;
        public bool? Banned { get; set; } = null;
        public IEnumerable<UserListDto>? Users { get; set; } = null;
    }
}
