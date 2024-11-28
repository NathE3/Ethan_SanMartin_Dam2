using CapturaPokemon.Utils;


namespace CapturaPokemon.Interface
{
    public interface IPokemonService
    {
        Task <List<Pokemon>> ProcesarPokemons();
        Task<Pokemon>  GetPokemon();
    }
}
