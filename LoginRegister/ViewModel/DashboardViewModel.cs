using CommunityToolkit.Mvvm.ComponentModel;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.ViewModel;
using System.Collections.ObjectModel;

namespace LoginRegister.ViewModel;

public partial class DashboardViewModel : ViewModelBase
{

    private readonly IDicatadorServiceToApi _dicatadorServiceToApi;

    public DashboardViewModel(IDicatadorServiceToApi dicatadorServiceToApi)
    {
        _dicatadorServiceToApi = dicatadorServiceToApi;
        Dicatadores = new ObservableCollection<DicatadorDTO>();
    }

    [ObservableProperty]
    private ObservableCollection<DicatadorDTO> dicatadores;

    public override async Task LoadAsync()
    {
        Dicatadores.Clear();
        IEnumerable<DicatadorDTO> listaDicatadores = await _dicatadorServiceToApi.GetDicatadores();
        foreach (DicatadorDTO dicatador in listaDicatadores)
        {
            Dicatadores.Add(dicatador);
        }

    }

}
