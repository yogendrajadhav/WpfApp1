using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WpfApp1.Services
{
    public class NavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetViewModel<T>() where T : class
        {
            return this._serviceProvider.GetRequiredService<T>();
        }
    }

    public class SettingsService
    {
        private const string FilePath = "appsettings.json";
        public Settings Current { get; private set; }

        public SettingsService()
        {
            Load();
        }

        public void Load()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                Current = JsonSerializer.Deserialize<Settings>(json);
            }
            else
            {
                Current = new Settings(); // default settings
            }
        }
        public void Save()
        {
            var json = JsonSerializer.Serialize(Current, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

    }
    public class Settings
    {
        public string Theme { get; set; } = "Light";
    }

}
