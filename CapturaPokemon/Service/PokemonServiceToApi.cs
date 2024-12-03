using CapturaPokemon.Interface;
using CapturaPokemon.Models;
using CapturaPokemon.Utils;

namespace CapturaPokemon.Service
{

   public class PokemonServiceToApi : IPokemonServiceToApi
   {
        public static List<PokemonDTO>? ListaPokemon;

        public static List<PokemonDTO> GetInstance()
            {
                if (ListaPokemon == null)
                 {
                     ListaPokemon = new List<PokemonDTO>();
                 } 
                    return ListaPokemon;
   }

    public async Task<PokemonDTO> GetPokemon()
        {
        
         string url = Constants.POKEUS_URL; 

        
         PokemonDTO pokemon = await HttpJsonClient<PokemonDTO>.Get(url);
         return pokemon;
         }

   public async Task AddPokemonToApi(PokemonDTO pokemon)
        {
            if (pokemon == null) throw new ArgumentNullException(nameof(pokemon));

          
            string url = Constants.POKEUS_URL; 

           
            var response = await HttpJsonClient<PokemonDTO>.Post(url, pokemon);
            ListaPokemon?.Add(pokemon);

            if (!response.IsSuccessStatusCode)
            {
            throw new Exception($"Error al añadir Pokémon a la API: {response.ReasonPhrase}");
            }
         }

    public async Task<List<PokemonDTO>> ProcesarPokemons()
    {

        return await Task.FromResult(ListaPokemon ?? new List<PokemonDTO>());

    }

   public PokemonDTO ConvertirDTO(Pokemon pokemon, DateTime dateStart, DateTime dateEnd, int damageDoneTrainer, int damageReceivedTrainer, int damageDonePokemon)
     {
            if (pokemon == null)
                throw new ArgumentNullException(nameof(pokemon));

           
            return (new PokemonDTO
            {
                Id = pokemon.Id,
                PokeName = pokemon.PokemonName,
                PokeImagen = pokemon.ImagePath,
                Capturado = pokemon.Captura, 
                Shiny = pokemon.Shiny,

                
                DateStart = dateStart,  
                DateEnd = dateEnd,  
                DamageDoneTrainer =damageDoneTrainer, 
                DamageReceivedTrainer = damageReceivedTrainer,
                DamageDonePokemon = damageDonePokemon
            });
        }







   }
   
}