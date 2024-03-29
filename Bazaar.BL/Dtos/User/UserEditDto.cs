﻿
namespace Bazaar.BL.Dtos.User
{
    public class UserEditDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public bool? HasPremium { get; set; } = null!;
    }
}
