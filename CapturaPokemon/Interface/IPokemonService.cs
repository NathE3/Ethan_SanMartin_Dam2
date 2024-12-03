using CapturaPokemon.Models;


namespace CapturaPokemon.Interface
{
    public interface IPokemonService
    {
        Task <List<Pokemon>> ProcesarPokemons();
        Task<Pokemon>  GetPokemon();
    }
}
