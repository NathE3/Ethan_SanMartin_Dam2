using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegister.ViewModel
{
    public partial class InformacionViewModel : ViewModelBase
    {
        [ObservableProperty]
        public ObservableCollection<DicatadorDTO> items;

        [ObservableProperty]
        public ObservableCollection<AutorDTO> autores;

        public List<DicatadorDTO> itemsOriginales = new List<DicatadorDTO>();


        [ObservableProperty]
        public string idAutorFiltro;

        private readonly IDicatadorServiceToApi _dicatadorServiceToApi;
        private readonly IHttpJsonProvider<AutorDTO> _httpjsonprovider;
        private readonly DetallesViewModel _detallesViewModel;
        private readonly IStringUtils _stringUtils;  

        [ObservableProperty]
        private ViewModelBase? _selectedViewModel;

        public InformacionViewModel(IDicatadorServiceToApi dicatadorServiceToApi, DetallesViewModel detallesViewModel, IStringUtils stringUtils, IHttpJsonProvider<AutorDTO> httpjsonprovider)
        {
            _dicatadorServiceToApi = dicatadorServiceToApi;
            _detallesViewModel = detallesViewModel;
            _stringUtils = stringUtils;
            _httpjsonprovider = httpjsonprovider;

            Items = new ObservableCollection<DicatadorDTO>();
            Autores = new ObservableCollection<AutorDTO>();      
        }

        public override async Task LoadAsync()
        {
            Items.Clear();
            Autores.Clear();
            itemsOriginales.Clear();


            IEnumerable<DicatadorDTO> dicatadores = await _dicatadorServiceToApi.GetDicatadores();
            IEnumerable<AutorDTO> autoresAPI = await _httpjsonprovider.GetAsync(Constants.AUTOR_URL);


            foreach (var dicatador in dicatadores)
            {
                if (string.IsNullOrEmpty(dicatador.Image))
                {
                    dicatador.Image = Constants.PATH_IMAGE_NOT_FOUND;
                }
                Items.Add(dicatador);
                itemsOriginales.Add(dicatador);
            }
            
            Autores = new ObservableCollection<AutorDTO>(autoresAPI);
        }

        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            int id = _stringUtils.ConvertToInteger(parameter?.ToString() ?? string.Empty) ?? int.MinValue;
            _detallesViewModel.SetIdDicatador(id);
            _detallesViewModel.SetParentViewModel(this);
            SelectedViewModel = _detallesViewModel;
            await _detallesViewModel.LoadAsync();
        }


        [RelayCommand]
        private void Filtrar()
        {
            if (string.IsNullOrWhiteSpace(idAutorFiltro))
            {
                LoadAsync();
            }
            else
            {               
                var filtrados = itemsOriginales.Where(d => d.Id_autor.ToString() == idAutorFiltro).ToList();
                Items = new ObservableCollection<DicatadorDTO>(filtrados);
            }
        }
    }
}


