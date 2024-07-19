using Microsoft.Extensions.DependencyInjection;
using CourseManagement.Models;
using System.Windows;
using CourseManagement.ViewModels;
using CourseManagement.Containers;

namespace CourseManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            services.AddSingleton<AppDbContext>();
            services.AddTransient<CourseViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<NavigationContainer>();
            services.AddSingleton((services) => new MainWindow()
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
