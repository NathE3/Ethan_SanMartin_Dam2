using CapturaPokemon.Interface;
using CapturaPokemon.Models;
using CapturaPokemon.Services;
using CapturaPokemon.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using static CapturaPokemon.Interface.IFileService;

namespace CapturaPokemon.ViewModel
{
    public partial class ImportViewModel : ViewModelBase
    {
        private readonly IFileService<PokemonDTO> _fileService;

        [ObservableProperty]
        private ObservableCollection<PokemonDTO> pokemons;
        public ImportViewModel(IFileService<PokemonDTO> fileService) 
        {
            _fileService = fileService;
        }


        [RelayCommand]
        public void LoadFromFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = Constants.JSON_FILTER
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var loadedPokemons = _fileService.Load(openFileDialog.FileName);
                var actualizarPokemons = HttpJsonClient<PokemonDTO>.DeleteAll(Constants.POKEUS_URL);
                foreach (var pokemon in loadedPokemons) 
                {
                    HttpJsonClient<PokemonDTO>.Post(Constants.POKEUS_URL, pokemon);
                }

            }
        }
    }
}
