using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public MainViewModel(Pagina1ViewModel pagina1ViewModel, Pagina2ViewModel pagina2ViewModel, Pagina3ViewModel pagina3ViewModel, Pagina4ViewModel pagina4ViewModel)
        {
            Pagina1ViewModel = pagina1ViewModel;
            Pagina2ViewModel = pagina2ViewModel;
            Pagina3ViewModel = pagina3ViewModel;
            Pagina4ViewModel = pagina4ViewModel;
            _selectedViewModel = pagina1ViewModel;
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public Pagina1ViewModel Pagina1ViewModel { get; }
        public Pagina2ViewModel Pagina2ViewModel { get; }
        public Pagina3ViewModel Pagina3ViewModel { get; }
        public Pagina4ViewModel Pagina4ViewModel { get; }

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
