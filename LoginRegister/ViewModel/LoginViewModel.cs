using CommunityToolkit.Mvvm.Input;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.Helpers;
using System.Windows;
using Wpf.Ui;
using CommunityToolkit.Mvvm.ComponentModel;
using LoginRegister.ViewModel;
using LoginRegister.View;
using Microsoft.Extensions.DependencyInjection;

namespace LoginRegister.ViewModel
{
    public partial class LoginViewModel : ViewModelBase
    {
        private readonly IHttpJsonProvider<UserDTO> _httpJsonProvider;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _passwordView;

        public LoginViewModel(IHttpJsonProvider<UserDTO> httpJsonProvider)
        {
            _httpJsonProvider = httpJsonProvider;
          
        }

        [RelayCommand]
        public async Task Login()
        {

            LoginDTO loginDTO = new()
            {
                UserName = Name,
                Password = PasswordView
            };

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(PasswordView))
            {
                MessageBox.Show("Por favor, rellene ambos campos.", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Intentar autenticar al usuario
                UserDTO user = await _httpJsonProvider.LoginPostAsync(Constants.LOGIN_PATH, loginDTO);

                if (user != null && user.IsSuccess)
                {
                    App.Current.Services.GetService<MainViewModel>().SelectedViewModel = App.Current.Services.GetService<MainViewModel>().DashboardViewModel;
                    App.Current.Services.GetService<MainViewModel>().LoadAsync();
                 
                }
                else
                {
                    // Si las credenciales son incorrectas, mostrar un mensaje y permitir reintentar
                    MessageBox.Show("Credenciales incorrectas. Intente de nuevo.", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados, como problemas de red
                MessageBox.Show($"Ocurrió un error durante el inicio de sesión: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        [RelayCommand]
        private async void Register()
        {

            var mainWindow = App.Current.Services.GetService<MainViewModel>();
            mainWindow.SelectedViewModel = App.Current.Services.GetService<MainViewModel>().RegistroViewModel;
        }
    }
}

