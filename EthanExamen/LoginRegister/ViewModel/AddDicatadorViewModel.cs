using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace LoginRegister.ViewModel
{
    public partial class AddDicatadorViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private string _pais;

        [ObservableProperty]
        private int _idAutor;

        private readonly IDicatadorServiceToApi _dicatadorServiceToApi;
        private readonly IHttpJsonProvider<AutorDTO> _httpjsonprovider;

        public AddDicatadorViewModel(IDicatadorServiceToApi dicatadorServiceToApi, LoginDTO loginDTO, IHttpJsonProvider<AutorDTO> httpjsonprovider)
        {
            _dicatadorServiceToApi = dicatadorServiceToApi;
            _httpjsonprovider = httpjsonprovider;
        }

        [RelayCommand]
        public async Task Add()
        {
            bool exit = await AutorExits(IdAutor);
            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(Description) ||
                string.IsNullOrEmpty(Pais) || !exit) 
            {
                MessageBox.Show("Algun campo incorrecto o vacio.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DicatadorDTO dicatadorDTO = new()
            {
                
                Name = Name,
                Description = Description,
                Pais = Pais,
                Id_autor = IdAutor,
            };

            if (string.IsNullOrEmpty(dicatadorDTO.Image)){
                dicatadorDTO.Image = "";
            }

            try
            {
                await _dicatadorServiceToApi.PostDicatador(dicatadorDTO);
                 
                 MessageBox.Show("Dicatador añadido con exito");
                 App.Current.Services.GetService<MainViewModel>().LoadAsync();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error durante el registro: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }
        public async Task<bool> AutorExits(int id) 
        {
            IEnumerable<AutorDTO> autoresAPI = await _httpjsonprovider.GetAsync(Constants.AUTOR_URL);

            foreach(var autor in autoresAPI) 
            {
                if(id == autor.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}


