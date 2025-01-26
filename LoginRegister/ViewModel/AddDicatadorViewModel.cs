using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Xml.Linq;

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

        private readonly IDicatadorServiceToApi _dicatadorServiceToApi;
       

        public AddDicatadorViewModel(IDicatadorServiceToApi dicatadorServiceToApi, LoginDTO loginDTO)
        {
            _dicatadorServiceToApi = dicatadorServiceToApi;          
        }

        [RelayCommand]
        public async Task Add()
        {
            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(Description) ||
                string.IsNullOrEmpty(Pais))
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DicatadorDTO dicatadorDTO = new()
            {
                Name = Name,
                Description = Description,
                Pais = Pais,
            };

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
    }
}


