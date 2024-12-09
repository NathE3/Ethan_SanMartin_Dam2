using CapturaPokemon.Interface;
using CapturaPokemon.Models;
using CapturaPokemon.Services;
using CapturaPokemon.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;

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
        public async Task LoadFromFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = Constants.JSON_FILTER
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var datos = _fileService.Load(openFileDialog.FileName);
                await HttpJsonClient<PokemonDTO>.DeleteAll(Constants.POKEUS_URL + "deleteAll");
                foreach (var pokemon in datos)
                {
                    HttpJsonClient<PokemonDTO>.Post(Constants.POKEUS_URL, pokemon);
                }             
            }
        }
    }
}
