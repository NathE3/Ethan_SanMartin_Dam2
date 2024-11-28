using CommunityToolkit.Mvvm.ComponentModel;

namespace CapturaPokemon.ViewModel
{
    public class ViewModelBase : ObservableObject
        {
            public virtual Task LoadAsync() => Task.CompletedTask;
        }
}


