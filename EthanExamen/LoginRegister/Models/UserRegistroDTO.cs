using System.Text.Json.Serialization;

namespace LoginRegister.Models
{
    public class UserRegistroDTO
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
