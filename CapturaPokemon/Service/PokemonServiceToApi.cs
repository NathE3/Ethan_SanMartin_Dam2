using CapturaPokemon.Interface;
using CapturaPokemon.Models;
using CapturaPokemon.Utils;

namespace CapturaPokemon.Service
{

   public class PokemonServiceToApi : IPokemonServiceToApi
   {
    public async Task<PokemonDTO> GetPokemon()
        {
        
         string url = Constants.POKEUS_URL; 

        
         PokemonDTO pokemon = await HttpJsonClient<PokemonDTO>.Get(url);
         return pokemon;
         }

        public async Task AddPokemonToApi(object pokemon)
            {
                try
                {
                    if (pokemon == null) return;
                    var response = await HttpJsonClient<PokemonDTO>.Post(Constants.POKEUS_URL, pokemon);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
            }
            }

        public async Task<List<PokemonDTO>> GetAllPokemons()
        {
            try
            {
                var pokemons = await HttpJsonClient<List<PokemonDTO>>.Get(Constants.POKEUS_URL);
                return pokemons ?? new List<PokemonDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de la  API: {ex.Message}");
                return new List<PokemonDTO>();
            }
        }

        public int GenerarIdAleatorio()
        {
            Random random = new Random();          
            return random.Next(1, 2001);
        }

    }
   
}