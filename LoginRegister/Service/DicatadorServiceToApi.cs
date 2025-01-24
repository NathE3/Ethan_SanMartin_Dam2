using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.Services;



namespace LoginRegister.Service
{

   public class DicatadorServiceToApi : IDicatadorServiceToApi
   {
        private readonly IHttpJsonProvider<DicatadorDTO> _httpJsonProvider;

        public DicatadorServiceToApi(IHttpJsonProvider<DicatadorDTO>  httpJsonProvider) 
        {
            _httpJsonProvider = httpJsonProvider;
        }



         public async  Task<IEnumerable<DicatadorDTO>> GetDicatadores()
         {
 
            IEnumerable<DicatadorDTO> dicatadores = await _httpJsonProvider.GetAsync(Constants.BASE_URL);

         return dicatadores;
         }

        public async Task PostDicatador(DicatadorDTO dicatador)
            {
                try
                {
                    if (dicatador == null) return;
                    var response = await _httpJsonProvider.PostAsync(Constants.BASE_URL,dicatador);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        public async Task PutDicatador(DicatadorDTO dicatador)
        {
            try
            {
                if (dicatador == null) return;
                var response = await _httpJsonProvider.PutAsync(Constants.BASE_URL, dicatador);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
   
}