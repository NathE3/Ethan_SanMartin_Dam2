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
using LoginRegister.Helpers;

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
            services.AddSingleton<AddDicatadorView>();


            //view viewModels
            services.AddSingleton<MainViewModel>();
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddSingleton<AddDicatadorViewModel>();
            services.AddTransient<RegistroViewModel>();
            services.AddTransient<ViewModelBase>();
      


            //Services
            services.AddSingleton<LoginDTO>();   
            services.AddSingleton<IDicatadorServiceToApi, DicatadorServiceToApi>();
            services.AddSingleton(typeof(IHttpJsonProvider<>), typeof(HttpJsonService<>));
            return services.BuildServiceProvider();
        }
    }
}


