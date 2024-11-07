using CommunityToolkit.Mvvm.ComponentModel;

namespace GestionArchivos.ViewModel
{
    public class ViewModelBase : ObservableObject
        {
            public virtual Task LoadAsync() => Task.CompletedTask;
        }
}


