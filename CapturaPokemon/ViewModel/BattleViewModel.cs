using CommunityToolkit.Mvvm.Input;
using CapturaPokemon.Interface;
using CommunityToolkit.Mvvm.ComponentModel;


namespace CapturaPokemon.ViewModel
{
    public partial class BattleViewModel : ViewModelBase
    {
        //Importante crear la inyeccion de servicios
        private readonly IPokemonService _pokemonService;

        [ObservableProperty]
        public string? _PokemonName;
        [ObservableProperty]
        public string? _ImagePath;

        [ObservableProperty]
        public int? _PokeAtaque;
        [ObservableProperty]
        public int? _PokeHp;

   
        public BattleViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async  Task CrearPokemon()
        {
            var pokemon = await _pokemonService.GetPokemon();
            ImagePath = pokemon.ImagePath;
            PokemonName = pokemon.PokemonName;
            PokeAtaque = pokemon.PokeAtaque;
            PokeHp =  pokemon.PokeHp;
       
        }

        public override async Task LoadAsync()
        {
            await CrearPokemon();
            await base.LoadAsync();
        }
    }
}



