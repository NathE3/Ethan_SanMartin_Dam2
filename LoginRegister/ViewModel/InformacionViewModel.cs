using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegister.ViewModel
{
    public partial class InformacionViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<DicatadorDTO> items;

        private readonly IDicatadorServiceToApi _dicatadorServiceToApi;
        private readonly DetallesViewModel _detallesViewModel;
        private readonly IStringUtils _stringUtils;

        [ObservableProperty]
        private ViewModelBase? _selectedViewModel;

        public InformacionViewModel(IDicatadorServiceToApi dicatadorServiceToApi, DetallesViewModel detallesViewModel, IStringUtils stringUtils)
        {
            _dicatadorServiceToApi = dicatadorServiceToApi;
            _detallesViewModel = detallesViewModel;
            _stringUtils = stringUtils;
            items = new ObservableCollection<DicatadorDTO>();
        }

        public override async Task LoadAsync()
        {
            Items.Clear();
            IEnumerable<DicatadorDTO> dicatatores = await _dicatadorServiceToApi.GetDicatadores();
            foreach (var dicatador in dicatatores)
            {
                if (string.IsNullOrEmpty(dicatador.Image))
                {
                    dicatador.Image = Constants.PATH_IMAGE_NOT_FOUND;
                }
                items.Add(dicatador);
            }
        }

        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            _detallesViewModel.SetIdDicatador(_stringUtils.ConvertToInteger(parameter?.ToString() ?? string.Empty) ?? int.MinValue);
            _detallesViewModel.SetParentViewModel(this);
            SelectedViewModel = _detallesViewModel;
            await _detallesViewModel.LoadAsync();
        }
    }
}
