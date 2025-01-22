using CommunityToolkit.Mvvm.Input;
using Pro_WPF.Interface;
using Pro_WPF.Models;
using Pro_WPF.Helpers;
using System;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui;
using Pro_WPF.Views.Pages;

namespace Pro_WPF.ViewModels
{
    public partial class LoginViewModel : ViewModel
    {
        private readonly IHttpJsonProvider<UserDTO> _httpJsonProvider;

        public INavigationService NavigationService { get; }

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _passwordView;

        public LoginViewModel(IHttpJsonProvider<UserDTO> httpJsonProvider, INavigationService navigationService)
        {
            _httpJsonProvider = httpJsonProvider;
            NavigationService = navigationService;
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
                    // Si el inicio de sesión es exitoso, navegar a la página del dashboard
                    NavigationService.Navigate(typeof(Views.Pages.DashboardPage));
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
        private void NavigateToRegisterView()
        {
            NavigationService?.Navigate(typeof(Views.Pages.RegistroView));
        }
    }
}

