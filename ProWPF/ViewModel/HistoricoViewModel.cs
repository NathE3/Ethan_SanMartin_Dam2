

using ProWPF.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using ProWPF.Utils;
using ProWPF.Models;

namespace ProWPF.ViewModel
{
    public partial class HistoricoViewModel : ViewModelBase
    {
      
        private readonly IDicatadorServiceToApi _dicatadorToApi;

        public HistoricoViewModel(IDicatadorServiceToApi dicacatadorToApi)
        {

            _dicatadorToApi = dicacatadorToApi;
            Dicatadores = new ObservableCollection<DicatadorDTO>();
        }

        [ObservableProperty]
        private ObservableCollection<DicatadorDTO> dicatadores;

        public override async Task LoadAsync()
        {
            Dicatadores.Clear();
            List<DicatadorDTO> listaDicatadores = await HttpJsonClient<List<DicatadorDTO>>.Get(Constants.BASE_URL); 
            foreach (DicatadorDTO dicatador in listaDicatadores)
            {
                Dicatadores.Add(dicatador);
            }
         
        }
    }
}
