using System;
using System.Collections.Generic;
using System.IO;

public class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private static readonly object _lock = new object();
    private Dictionary<string, string> _settings;

    private ConfigurationManager()
    {
        _settings = new Dictionary<string, string>();
    }

    public static ConfigurationManager GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationManager();
                }
            }
        }
        return _instance;
    }

    public void LoadSettings(string filePath)
    {
        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('=');
                if (parts.Length == 2)
                {
                    _settings[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }
    }

    public string GetSetting(string key)
    {
        return _settings.ContainsKey(key) ? _settings[key] : null;
    }

    public void SetSetting(string key, string value)
    {
        if (_settings.ContainsKey(key))
        {
            _settings[key] = value;
        }
        else
        {
            _settings.Add(key, value);
        }
    }

    public void SaveSettings(string filePath)
    {
        var lines = new List<string>();
        foreach (var setting in _settings)
        {
            lines.Add($"{setting.Key}={setting.Value}");
        }
        File.WriteAllLines(filePath, lines);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var config = ConfigurationManager.GetInstance();
        config.LoadSettings("config.txt");
        config.SetSetting("Theme", "Dark");
        config.SaveSettings("config.txt");

        var anotherConfig = ConfigurationManager.GetInstance();
        Console.WriteLine(anotherConfig.GetSetting("Theme"));
    }
}
