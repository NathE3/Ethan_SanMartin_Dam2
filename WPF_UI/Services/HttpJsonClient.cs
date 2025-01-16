using Pro_WPF.Interface;
using System.Net.Http;
using System.Text.Json;
using WPF_UI.Utils;


namespace Pro_WPF.Services
{

        internal class HttpJsonService<T> : IHttpJsonProvider<T> where T : class
        {
            public string Token = string.Empty;
            public async Task<IEnumerable<T>> GetAsync(string api_url)
            {
                try
                {
                    using HttpClient httpClient = new HttpClient();
                    {
                        HttpResponseMessage datos = await httpClient.GetAsync($"{Constants.BASE_URL}{api_url}");
                        string dataget = await datos.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<IEnumerable<T>>(dataget);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return default;
            }

            public async Task<T> PostAsync(T data, string api_url)
            {
                try
                {
                    using HttpClient httpClient = new HttpClient();
                    {
                        HttpContent httpContent = new StringContent(JsonSerializer.Serialize(data));

                        HttpResponseMessage datos = await httpClient.PostAsync($"{Constants.BASE_URL}{api_url}", httpContent);
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

            public async Task<T> PutAsync(T data, string api_url, int id)
            {
                try
                {
                    using HttpClient httpClient = new HttpClient();
                    {
                        HttpContent httpContent = new StringContent(JsonSerializer.Serialize(data));

                        HttpResponseMessage datos = await httpClient.PutAsync($"{Constants.BASE_URL}{Constants.DICATADOR_URL}", httpContent);
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

        public async Task<T?> GetToken(string path)
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





