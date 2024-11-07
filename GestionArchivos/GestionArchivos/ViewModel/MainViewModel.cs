using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace GestionArchivos.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public MainViewModel(InfoViewModel infoViewModel, FileViewModel fileViewModel, InicioViewModel inicioViewModel)
        {
            InfoViewModel = infoViewModel;
            FileViewModel = fileViewModel;
            _selectedViewModel = inicioViewModel; 
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public InfoViewModel InfoViewModel { get; }
        public FileViewModel FileViewModel { get; }

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
}

