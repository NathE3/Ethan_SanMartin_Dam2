using Examen.Interface;
using Examen.Service;
using Examen.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Examen
{
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
            services.AddTransient<Pagina1ViewModel>();
            services.AddTransient<Pagina2ViewModel>();
            services.AddTransient<Pagina3ViewModel>();
            services.AddTransient<Pagina4ViewModel>();



            //Services
            //services.AddSingleton<IPokemonService, PokemonService>();
            services.AddSingleton<IApiRafaService,ApiRafaService>();
            services.AddSingleton(typeof(IFileService<>), typeof(FileService<>));
            return services.BuildServiceProvider();
        }
    }

}
