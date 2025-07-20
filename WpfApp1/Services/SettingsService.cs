using System.IO;
using System.Text.Json;

namespace WpfApp1.Services;

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