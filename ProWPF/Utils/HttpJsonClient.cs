using System.Net.Http;
using System.Text;
using System.Text.Json;


namespace ProWPF.Utils
{

    public static class HttpJsonClient<T>
    {


        public static string Token = string.Empty;
        public static async Task<T> Get(string path)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    HttpResponseMessage datos = await httpClient.GetAsync(path);
                    string dataget = await datos.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataget);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }


        public static async Task<object> Post(string url, object data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Serializar el objeto 'data' (PokemonDTO) a JSON
                    string jsonContent = JsonSerializer.Serialize(data);

                    // Crear el contenido HTTP con el tipo adecuado para enviar JSON
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Realizar la solicitud POST
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    // Verificar si la respuesta fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta y deserializarlo
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        Console.WriteLine("Error en la respuesta: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud POST: {ex.Message}");
            }
            return default;
        }

        public static async Task<T?> GetToken(string path)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
                    HttpResponseMessage request = await httpClient.GetAsync($"{Constants.BASE_URL}{path}");
                    if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        HttpResponseMessage requestToken = await httpClient.GetAsync($"{Constants.BASE_URL}{Constants.LOGIN_PATH}/login");
                    }
                    string dataRequest = await request.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

    }
}





