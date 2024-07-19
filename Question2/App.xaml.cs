using Microsoft.Extensions.DependencyInjection;
using CourseManagement.Models;
using System.Windows;

namespace CourseManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            services.AddScoped<AppDbContext>();
            services.AddTransient<MainWindow>();
            var provider = services.BuildServiceProvider();
            provider.GetRequiredService<MainWindow>().Show();
        }
    }

}
