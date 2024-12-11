using CommunityToolkit.Mvvm.ComponentModel;

namespace Examen.ViewModel
{
    public class ViewModelBase : ObservableObject
    {
        public virtual Task LoadAsync() => Task.CompletedTask;
    }
}
