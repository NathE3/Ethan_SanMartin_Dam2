// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using CommunityToolkit.Mvvm.Input;
using LoginRegister.ViewModel;

namespace LoginRegister.ViewModel;

public partial class MainViewModel : ViewModelBase
{
       private ViewModelBase? _selectedViewModel;

        public MainViewModel(DashboardViewModel dashboardViewModel, LoginViewModel loginViewModel, RegistroViewModel registroViewModel, SettingsViewModel settingsViewModel)
        {
            DashboardViewModel = dashboardViewModel;
            LoginViewModel = loginViewModel;
            RegistroViewModel = registroViewModel;
            SettingsViewModel = settingsViewModel;
            _selectedViewModel = loginViewModel;
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public DashboardViewModel DashboardViewModel { get; }
        public LoginViewModel LoginViewModel { get; }
        public RegistroViewModel RegistroViewModel { get; }
        public SettingsViewModel SettingsViewModel { get; }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        [RelayCommand]
        private async Task SelectViewModelAsync(object? parameter)
        {
            if (parameter is ViewModelBase viewModel)
            {
                SelectedViewModel = viewModel;
                await LoadAsync();
            }
        }
}
 

   

