using CommunityToolkit.Mvvm.ComponentModel;

namespace ProWPF.ViewModel
{
    public class ViewModelBase : ObservableObject
        {
            public virtual Task LoadAsync() => Task.CompletedTask;
        }
}


