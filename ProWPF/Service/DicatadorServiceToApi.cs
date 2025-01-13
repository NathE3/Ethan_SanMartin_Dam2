using ProWPF.Utils;
using ProWPF.Interface;
using ProWPF.Models;

namespace ProWPF.Service
{

   public class DicatadorServiceToApi : IDicatadorServiceToApi
   {
         public async Task<DicatadorDTO> GetDicatador()
         {
        
         string url = Constants.BASE_URL; 

        
         DicatadorDTO dicatador = await HttpJsonClient<DicatadorDTO>.Get(url);
         return dicatador;
         }

        public async Task PostDicatador(object dicatador)
            {
                try
                {
                    if (dicatador == null) return;
                    var response = await HttpJsonClient<DicatadorDTO>.Post(Constants.BASE_URL, dicatador);
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
                var dicatador = await HttpJsonClient<List<DicatadorDTO>>.Get(Constants.BASE_URL);
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