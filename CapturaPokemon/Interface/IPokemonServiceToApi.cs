using CapturaPokemon.Models;


namespace CapturaPokemon.Interface
{
    public interface IPokemonServiceToApi
    {
        // Obtiene un Pokémon desde la API
        Task<PokemonDTO> GetPokemon();

        // Agrega un Pokémon a la API
        Task AddPokemonToApi(PokemonDTO pokemon);

        // Procesa y devuelve la lista de Pokémon almacenados
        Task<List<PokemonDTO>> ProcesarPokemons();

        PokemonDTO ConvertirDTO(Pokemon pokemon, DateTime dateStart, DateTime dateEnd, int damageDoneTrainer, int damageReceivedTrainer, int damageDonePokemon);
    }
}
