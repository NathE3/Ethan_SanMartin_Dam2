using Ferraro.Models.Entity;

namespace Ferraro.Models.DTOs.UserDto
{
    public class UserLoginResponseDto
    {
        public AppUser User { get; set; }
        public string Token { get; set; }

    }
}
