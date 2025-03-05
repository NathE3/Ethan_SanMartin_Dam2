using CommunityToolkit.Mvvm.Input;


namespace LoginRegister.ViewModel;

public partial class MainViewModel : ViewModelBase
{
    private ViewModelBase? _selectedViewModel;
    private bool _isMenuEnabled;
    public MainViewModel(DashboardViewModel dashboardViewModel, LoginViewModel loginViewModel, RegistroViewModel registroViewModel, AddDicatadorViewModel addViewModel, InformacionViewModel informacionViewModel, DetallesViewModel detallesViewModel)
    {
        DashboardViewModel = dashboardViewModel;
        LoginViewModel = loginViewModel;
        RegistroViewModel = registroViewModel;
        AddDicatadorViewModel = addViewModel;
        InformacionViewModel = informacionViewModel;
        DetallesViewModel = detallesViewModel;
        _selectedViewModel = loginViewModel;
        IsMenuEnabled = false;

    }

    public ViewModelBase? SelectedViewModel
    {
        get => _selectedViewModel;
        set
        {
            SetProperty(ref _selectedViewModel, value);
            if (value is LoginViewModel || value is RegistroViewModel)
            {
                IsMenuEnabled = false;
            }
            else
            {
                IsMenuEnabled = true;
            }
        }
    }

    public DashboardViewModel DashboardViewModel { get; }
    public LoginViewModel LoginViewModel { get; }
    public RegistroViewModel RegistroViewModel { get; }
    public AddDicatadorViewModel AddDicatadorViewModel { get; }
    public InformacionViewModel InformacionViewModel { get; }
    public DetallesViewModel DetallesViewModel { get; }


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

    public bool IsMenuEnabled
    {
        get => _isMenuEnabled;
        set => SetProperty(ref _isMenuEnabled, value);
    }
}




