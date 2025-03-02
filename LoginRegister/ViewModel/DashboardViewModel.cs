using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.View;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace LoginRegister.ViewModel;

public partial class DashboardViewModel : ViewModelBase
{
    private readonly IDicatadorServiceToApi _dicatadorServiceToApi;
    private readonly AddDicatadorViewModel _addViewModel;
    private readonly InformacionViewModel _infoViewModel;

    public DashboardViewModel(IDicatadorServiceToApi dicatadorServiceToApi, AddDicatadorViewModel addViewModel, InformacionViewModel infoViewModel)
    {
        _dicatadorServiceToApi = dicatadorServiceToApi;
        _addViewModel = addViewModel;
        _infoViewModel = infoViewModel;
        Dicatadores = new List<DicatadorDTO>(); 
        PagedDicatadores = new ObservableCollection<DicatadorDTO>();

        ItemsPerPage = 5; 
        CurrentPage = 0; 
    }

    private List<DicatadorDTO> Dicatadores; 

    [ObservableProperty]
    private ObservableCollection<DicatadorDTO> pagedDicatadores;

    [ObservableProperty]
    private int currentPage; 

    [ObservableProperty]
    private int itemsPerPage; 

    public int TotalPages => (int)Math.Ceiling((double)Dicatadores.Count / ItemsPerPage);

 
    public override async Task LoadAsync()
    {
        try
        {
            
            Dicatadores.Clear();
            PagedDicatadores.Clear();

          
            IEnumerable<DicatadorDTO> listaDicatadores = await _dicatadorServiceToApi.GetDicatadores();
            Dicatadores.AddRange(listaDicatadores.OrderBy(d => d.Id));

          
            CurrentPage = 0;
            UpdatePagedDicatadores();
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error al cargar datos: {ex.Message}");
        }
    }

   
    private void UpdatePagedDicatadores()
    {
       
        PagedDicatadores.Clear();

        var pagedItems = Dicatadores.Skip(CurrentPage * ItemsPerPage).Take(ItemsPerPage).ToList();
        foreach (var item in pagedItems)
        {
            PagedDicatadores.Add(item);
        }
    }

    [RelayCommand]
    public async Task AddDicatador()
    {
        var addDicatadorWindow = new AddDicatadorView();

        var addDicatadorViewModel = App.Current.Services.GetService<AddDicatadorViewModel>();
        addDicatadorWindow.DataContext = addDicatadorViewModel;
        addDicatadorWindow.ShowDialog();       
        await LoadAsync();
    }


    [RelayCommand]
    public async Task Logout() 
    {
        App.Current.Services.GetService<LoginDTO>().Token = "";
        App.Current.Services.GetService<MainViewModel>().SelectedViewModel = App.Current.Services.GetService<MainViewModel>().LoginViewModel;
    }

    [RelayCommand]
    public void PreviousPage()
    {
        if (CurrentPage > 0)
        {
            CurrentPage--;
            UpdatePagedDicatadores();
        }
    }

    [RelayCommand]
    public void NextPage()
    {
        if (CurrentPage < TotalPages - 1)
        {
            CurrentPage++;
            UpdatePagedDicatadores();
        }
    }
    public async void  MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.Row.Item is DicatadorDTO dicatadorDTO)
        {
           await _dicatadorServiceToApi.PutDicatador(dicatadorDTO);
        }
    }
    private bool CanGoToPreviousPage() => CurrentPage > 0;

    private bool CanGoToNextPage() => CurrentPage < TotalPages - 1;

    [RelayCommand]
    public void Info()
    {
        App.Current.Services.GetService<MainViewModel>().SelectedViewModel = App.Current.Services.GetService<MainViewModel>().InformacionViewModel;
        App.Current.Services.GetService<MainViewModel>().LoadAsync();
    }
}

