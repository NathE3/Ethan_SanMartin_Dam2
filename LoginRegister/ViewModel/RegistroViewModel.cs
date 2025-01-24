using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui;

namespace LoginRegister.ViewModel
{
    public partial class RegistroViewModel : ViewModelBase
    {
        [ObservableProperty]
        string _name;

        [ObservableProperty]
        string _userName;

        [ObservableProperty]
        string _email;

        [ObservableProperty]
        string _password;

        private readonly IHttpJsonProvider<UserDTO> _httpJsonProvider;
        public INavigationService NavigationService { get; }

        public RegistroViewModel(IHttpJsonProvider<UserDTO> httpJsonProvider, INavigationService navigationService)
        {
            _httpJsonProvider = httpJsonProvider;
            NavigationService = navigationService;
        }

        [RelayCommand]
        public async Task Registro()
        {

                UserRegistroDTO userRegistroDTO = new() 
                { 
                    Name = Name, 
                    UserName = UserName, 
                    Email = Email,
                    Password = Password, 
                    Role = "user" };

                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                    {
                         MessageBox.Show("Porfavor rellene todos los campos");
                    }
          
    
                try
                {
                    
                    UserDTO user = await _httpJsonProvider.RegisterPostAsync(Constants.REGISTER_PATH, userRegistroDTO);

                    if (user != null && user.IsSuccess)
                    {
                        NavigationService.Navigate(typeof(View.LoginView));
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas. Intente de nuevo.", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error durante el registro: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }
    }
}

