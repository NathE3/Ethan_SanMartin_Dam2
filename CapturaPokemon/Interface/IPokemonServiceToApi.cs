using CapturaPokemon.Models;


namespace CapturaPokemon.Interface
{
    public interface IPokemonServiceToApi
    {
        // Obtiene un Pokémon desde la API
        Task<PokemonDTO> GetPokemon();

        // Agrega un Pokémon a la API
        Task AddPokemonToApi(object pokemon);

        // Procesa y devuelve la lista de Pokémon almacenados
        Task<List<PokemonDTO>> GetAllPokemons();

        public Guid GenerarIdAleatorio();
    }
}
