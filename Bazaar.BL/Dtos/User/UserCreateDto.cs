
namespace Bazaar.BL.Dtos
{
    public class UserCreateDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
    }
}
