using GestionArchivos.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace GestionArchivos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = Current.Services.GetService<MainWindow>();
            mainWindow?.Show();
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //view principal
            services.AddSingleton<MainWindow>();

            //view viewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<FileViewModel>();
            services.AddTransient<InfoViewModel>();
            services.AddTransient<ViewModelBase>();
            services.AddTransient<InicioViewModel>();

            //Services
          
            return services.BuildServiceProvider();
        }
    }
}


