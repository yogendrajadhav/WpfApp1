using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfApp1.Services;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register all services here
                    services.AddSingleton<WpfApp1.Services.NavigationService>();
                    services.AddSingleton<DialogService>();
                    services.AddSingleton<SettingsService>();

                    // Register view models
                    services.AddSingleton<MainViewModel>();
                    services.AddTransient<HomeViewModel>();
                    services.AddTransient<AboutViewModel>();
                    services.AddTransient<TodoItemViewModel>();

                    // Register views
                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            var mainViewModel = AppHost.Services.GetRequiredService<MainViewModel>();
            mainWindow.DataContext = mainViewModel;

            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }

        public void ApplyTheme(string themeName)
        {
            string path = $"Themes/{themeName}.xaml";
            var dict = new ResourceDictionary() { Source = new Uri(path, UriKind.Relative) };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

    }

}
