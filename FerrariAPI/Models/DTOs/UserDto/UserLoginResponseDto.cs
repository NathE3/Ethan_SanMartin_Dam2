using FerrariAPI.Models.Entity;

namespace FerrariAPI.Models.DTOs.UserDto
{
    public class UserLoginResponseDto
    {
        public AppUser User { get; set; }
        public string Token { get; set; }

    }
}
