using CommunityToolkit.Mvvm.Input;


namespace CapturaPokemon.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public MainViewModel(HistoricoViewModel historicoViewModel, BattleViewModel battleViewModel)
        {
            HistoricoViewModel = historicoViewModel;
            BattleViewModel = battleViewModel;
            _selectedViewModel = battleViewModel; 
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public HistoricoViewModel HistoricoViewModel { get; }
        public BattleViewModel BattleViewModel { get; }

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

