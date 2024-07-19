using Microsoft.Extensions.DependencyInjection;
using CourseManagement.Models;
using System.Windows;
using CourseManagement.ViewModels;

namespace CourseManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            services.AddScoped<AppDbContext>();
            services.AddTransient<CourseViewModel>();
            services.AddSingleton<MainViewModel>((services) => new MainViewModel(services.GetRequiredService<AppDbContext>()));
            services.AddSingleton<MainWindow>((services) => new MainWindow()
            {
                DataContext = services.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _serviceProvider.GetRequiredService<MainWindow>().Show();
        }
    }

}
