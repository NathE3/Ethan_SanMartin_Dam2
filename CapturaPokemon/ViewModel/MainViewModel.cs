using CommunityToolkit.Mvvm.Input;


namespace CapturaPokemon.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public bool IsMenuEnabled { get; }

        public MainViewModel(HistoricoViewModel historicoViewModel, BattleViewModel battleViewModel, TeamViewModel teamViewModel, ImportViewModel importViewModel)
        {
            HistoricoViewModel = historicoViewModel;
            BattleViewModel = battleViewModel;
            TeamViewModel = teamViewModel;
            ImportViewModel = importViewModel;
            _selectedViewModel = battleViewModel;
            IsMenuEnabled = false;
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public HistoricoViewModel HistoricoViewModel { get; }
        public BattleViewModel BattleViewModel { get; }
        public TeamViewModel TeamViewModel { get; }
        public ImportViewModel ImportViewModel { get; }

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

