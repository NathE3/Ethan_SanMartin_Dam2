using LoginRegister.ViewModel;
using System.Windows;

namespace LoginRegister
{
    public partial class MainWindow : Window
    {

        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        //De Normal no ponemos NUNCA async void, es siempre Task,
        //es necesario en este caso por respetar la signatura de Loaded
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }

}
