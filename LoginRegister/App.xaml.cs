using LoginRegister.ViewModel;
using LoginRegister.Service;
using LoginRegister.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using LoginRegister.Services;
using LoginRegister.Models;
using LoginRegister.ViewModel;
using Wpf.Ui;
using LoginRegister.View;

namespace LoginRegister
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
            services.AddSingleton<MainViewModel>();
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<RegistroViewModel>();
            services.AddTransient<ViewModelBase>();
      


            //Services
            services.AddSingleton<IDicatadorServiceToApi, DicatadorServiceToApi>();
            services.AddSingleton(typeof(IHttpJsonProvider<>), typeof(HttpJsonService<>));
            services.AddSingleton<INavigationService, NavigationService>();
            return services.BuildServiceProvider();
        }
    }
}


