using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CapturaPokemon.Utils
{
    public static class HttpJsonClient<T>
    {
        public static async Task<T?> Get(string url)
        {
          
                using HttpClient httpClient = new HttpClient();
                {

                    HttpResponseMessage datos = await httpClient.GetAsync(url);
                    string dataget = await datos.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataget);
                }
           
        }

        public static async Task<HttpResponseMessage> Post(string url, T data)
        {
            using HttpClient httpClient = new HttpClient();
            {
                // Serializar el objeto 'data' a JSON
                string jsonContent = JsonSerializer.Serialize(data);

                // Crear el contenido HTTP con el tipo adecuado para enviar JSON
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Realizar la solicitud POST
                return await httpClient.PostAsync(url, content);
            }
        }
    }
}
