﻿namespace Bazaar.BL.Dtos.User
{
    public class UserEditDetailDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
