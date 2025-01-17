using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pro_WPF.Interface
{
    public interface IHttpJsonProvider<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(string api_url);
        Task<T?> PostAsync(string path, T data);
        Task<T?> PutAsync(string path, T data);
        Task Authenticate(string path, HttpClient httpClient, HttpResponseMessage request);

    }

}
