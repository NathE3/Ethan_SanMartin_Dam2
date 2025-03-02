using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using Microsoft.Win32;
using System.Collections.ObjectModel;



namespace LoginRegister.ViewModel
{
    public partial class DetallesViewModel : ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<DicatadorDTO> _items;

        private int _dicatadorId;
        private InformacionViewModel _informacionViewModel;
        private readonly IHttpJsonProvider<DicatadorDTO> _httpJsonProvider;
        private readonly IFileService<DicatadorDTO> _fileService;

        [ObservableProperty]
        private DicatadorDTO _Dicatador;
     
        public DetallesViewModel(IHttpJsonProvider<DicatadorDTO> httpJsonProvider, IFileService<DicatadorDTO> fileService)
        {
            _httpJsonProvider = httpJsonProvider;
            _fileService = fileService;
            _items = new ObservableCollection<DicatadorDTO>();
        }

        public void SetIdDicatador(int id)
        {
            _dicatadorId = id;
        }

        public override async Task LoadAsync()
        {
            IEnumerable<DicatadorDTO> dicatadores = await _httpJsonProvider.GetAsync(Constants.DICATADOR_URL);
            foreach (var dicatador in dicatadores)
            {
                if (string.IsNullOrEmpty(dicatador.Image))
                {
                    dicatador.Image = "/Resources/Not_found.png";
                }
                Items.Add(dicatador);
            }
            Dicatador = dicatadores.FirstOrDefault(x => x.Id == _dicatadorId) ?? new DicatadorDTO();
        }

        internal void SetParentViewModel(ViewModelBase galaxyOverviewViewModel)
        {
            if (galaxyOverviewViewModel is InformacionViewModel informacionview)
            {
                _informacionViewModel = informacionview;
            }
        }

        [RelayCommand]
        private async Task Close(object? parameter)
        {
            if (_informacionViewModel != null)
            {
                _informacionViewModel.SelectedViewModel = null;
            }
        }

        [RelayCommand]
        public void Save()
        {
        
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Constants.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _fileService.Save(saveFileDialog.FileName, (IEnumerable<DicatadorDTO>)Dicatador);
            }
        }
    }
}
