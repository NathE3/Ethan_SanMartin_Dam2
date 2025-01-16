// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Pro_WPF.Models;
using System.Windows.Media;

namespace Pro_WPF.ViewModels;

public partial class DataViewModel : ViewModel
{
    private bool _isInitialized = false;

    [ObservableProperty]
    private List<DataColor> _colors = [];

    public override void OnNavigatedTo()
    {
        if (!_isInitialized)
        {
            InitializeViewModel();
        }
    }

    public override async Task OnNavigatedToAsync()
    {
       await Task.CompletedTask;
    }

    private void InitializeViewModel()
    {
        var random = new Random();
        Colors.Clear();

        for (int i = 0; i < 8192; i++)
        {
            Colors.Add(
                new DataColor
                {
                    Color = new SolidColorBrush(
                        Color.FromArgb(
                            200,
                            (byte)random.Next(0, 250),
                            (byte)random.Next(0, 250),
                            (byte)random.Next(0, 250)
                        )
                    )
                }
            );
        }

        _isInitialized = true;
    }
}
