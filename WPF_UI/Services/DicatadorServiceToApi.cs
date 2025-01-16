using Pro_WPF.Helpers;
using Pro_WPF.Interface;
using Pro_WPF.Models;
using Pro_WPF.Services;



namespace Pro_WPF.Service
{

   public class DicatadorServiceToApi : IDicatadorServiceToApi
   {
        private readonly IHttpJsonProvider<DicatadorDTO> _httpJsonProvider;

        DicatadorServiceToApi(IHttpJsonProvider<DicatadorDTO>  httpJsonProvider) 
        {
            _httpJsonProvider = httpJsonProvider;
        }

         public async  Task<IEnumerable<DicatadorDTO>> GetDicatadores()
         {
        
         string url = Constants.BASE_URL;


            IEnumerable<DicatadorDTO> dicatadores = await _httpJsonProvider.GetAsync(url);

         return dicatadores;
         }

        public async Task PostDicatador(DicatadorDTO dicatador)
            {
                try
                {
                    if (dicatador == null) return;
                    var response = await _httpJsonProvider<DicatadorDTO>.PostAsync(Constants.BASE_URL, dicatador);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        public  async Task<List<DicatadorDTO>> GetAllDicatadores()
        {
            try
            {
                var dicatador = await _httpJsonProvider<List<DicatadorDTO>>.(Constants.BASE_URL);
                return dicatador ?? new List<DicatadorDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de la  API: {ex.Message}");
                return new List<DicatadorDTO>();
            }
        }

    }
   
}