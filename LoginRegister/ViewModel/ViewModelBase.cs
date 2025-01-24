using CommunityToolkit.Mvvm.ComponentModel;

namespace LoginRegister.ViewModel
{
    public class ViewModelBase : ObservableObject
        {
            public virtual Task LoadAsync() => Task.CompletedTask;
        }
}


