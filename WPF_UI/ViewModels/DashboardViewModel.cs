// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Pro_WPF.Helpers;
using Pro_WPF.Interface;
using Pro_WPF.Models;
using System.Collections.ObjectModel;

namespace Pro_WPF.ViewModels;

public partial class DashboardViewModel : ViewModel
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
        Bimba();

    }

    public async void Bimba()
    {
        Dicatadores.Clear();

        IEnumerable<DicatadorDTO> listaDicatadores = await _httpJsonProvider.GetAsync(Constants.DICATADOR_URL);

        foreach (DicatadorDTO dicatador in listaDicatadores)
        {
            Dicatadores.Add(dicatador);
        }
     
    }

}
