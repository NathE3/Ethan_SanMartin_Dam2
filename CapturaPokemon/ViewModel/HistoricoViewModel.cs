
using CapturaPokemon.Models;
using CapturaPokemon.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CapturaPokemon.ViewModel
{
    public partial class HistoricoViewModel : ViewModelBase
    {
        private readonly IPokemonService _pokemonService;

        [ObservableProperty]
        public string? _PokemonName;

        [ObservableProperty]
        public string? _ImagePath;

        private ObservableCollection<Pokemon>? _pokemons;
        public ObservableCollection<Pokemon>? Pokemons
        {
            get { return _pokemons; }
            set
            {
                _pokemons = value;
                OnPropertyChanged(nameof(Pokemons));
            }
        }
        public HistoricoViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
            Pokemons = new ObservableCollection<Pokemon>();
        }
        
        public async Task CrearPokemons()
        {
            List<Pokemon>? pokemons = await _pokemonService.ProcesarPokemons();

            foreach (Pokemon poke in pokemons)
            {
                if (!Pokemons.Contains(poke)) 
                    {
                    Pokemons?.Add(poke); 
                    }    
            }
        }

        public override async Task LoadAsync()
        {
            await CrearPokemons();
            await base.LoadAsync();
        }
    }
}