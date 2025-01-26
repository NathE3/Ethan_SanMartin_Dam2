using System.Text.Json.Serialization;


namespace LoginRegister.Models
{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public class UserDTO
        {
            [JsonPropertyName("statusCode")]
            public int StatusCode { get; set; }

            [JsonPropertyName("isSuccess")]
            public bool IsSuccess { get; set; }

            [JsonPropertyName("errorMessages")]
            public List<object> ErrorMessages { get; set; }

            [JsonPropertyName("result")]
            public Result Result { get; set; }
        }

        public class Result
        {
            [JsonPropertyName("token")]
            public string Token { get; set; }
        }
}

