using CommunityToolkit.Mvvm.ComponentModel;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.ViewModel;
using System.Collections.ObjectModel;

namespace LoginRegister.ViewModel;

public partial class DashboardViewModel : ViewModelBase
{
    public readonly IDicatadorServiceToApi _dicatadorServiceApi;
    private readonly IHttpJsonProvider<DicatadorDTO> _httpJsonProvider;

    [ObservableProperty]
    private ObservableCollection<DicatadorDTO> dicatadores;

    private bool _isInitialized = false;

    public DashboardViewModel(IDicatadorServiceToApi dicatadorApi, IHttpJsonProvider<DicatadorDTO> httpJsonProvider)
    {

        _dicatadorServiceApi = dicatadorApi;
        _httpJsonProvider = httpJsonProvider;
        Dicatadores = [];

    }

   
   public async Task CogerDicatadores()
    {
        Dicatadores.Clear();

        IEnumerable<DicatadorDTO> listaDicatadores = await _httpJsonProvider.GetAsync(Constants.DICATADOR_URL);

        foreach (DicatadorDTO dicatador in listaDicatadores)
        {
            Dicatadores.Add(dicatador);
        }
     
    }

    override
   public async Task LoadAsync()
    {
        await CogerDicatadores();
        await base.LoadAsync();
    }

}
