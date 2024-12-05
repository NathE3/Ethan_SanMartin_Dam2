
using CapturaPokemon.Models;
using CapturaPokemon.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CapturaPokemon.Service;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using static CapturaPokemon.Interface.IFileService;
using System.Reflection.Metadata;
using CapturaPokemon.Utils;
using CapturaPokemon.Services;

namespace CapturaPokemon.ViewModel
{
    public partial class HistoricoViewModel : ViewModelBase
    {
      
        private readonly IPokemonServiceToApi _pokemonServiceToApi;
        private readonly IFileService<PokemonDTO> _fileService;

        public HistoricoViewModel(IPokemonServiceToApi pokemontoApi, IFileService<PokemonDTO> fileService)
        {
            _fileService = fileService;
            _pokemonServiceToApi = pokemontoApi;
            Pokemons = new ObservableCollection<PokemonDTO>();
        }

        [ObservableProperty]
        private ObservableCollection<PokemonDTO> pokemons;

        public override async Task LoadAsync()
        {
            Pokemons.Clear();
            List<PokemonDTO> mierdaPuta = await HttpJsonClient<List<PokemonDTO>>.Get(Constants.POKEUS_URL); 
            foreach (PokemonDTO poke in mierdaPuta)
            {
                Pokemons.Add(poke);
            }
         
        }

        [RelayCommand]
        public void SaveToFile()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Constants.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _fileService.Save(saveFileDialog.FileName, Pokemons);
            }
        }


    }
}
