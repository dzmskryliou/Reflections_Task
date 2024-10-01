using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
namespace Reflections_Task
{
    public static class FileConfigurationProvider
    {
        private static readonly string FilePath = "appsettings.json";

        private static Dictionary<string, string> LoadAllSettings()
        {
            if (!File.Exists(FilePath) || new FileInfo(FilePath).Length == 0)
            {
                return new Dictionary<string, string>();
            }

            try
            {
                var json = File.ReadAllText(FilePath);
                var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                if (result == null)
                {
                    return new Dictionary<string, string>();
                }
                return result;
            }
            catch (JsonReaderException)
            {
                Console.WriteLine("Invalid JSON in appsettings.json. Initializing empty configuration.");
                return new Dictionary<string, string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading settings from file: {ex.Message}");
                return new Dictionary<string, string>();
            }
        }

        private static void SaveAllSettings(Dictionary<string, string> settings)
        {
            try
            {
                var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving settings to file: {ex.Message}");
            }
        }

        public static void SaveSetting(string key, string value)
        {
            var settings = LoadAllSettings();
            settings[key] = value;
            SaveAllSettings(settings);
        }

        public static string LoadSetting(string key)
        {
            var settings = LoadAllSettings();
            return settings.ContainsKey(key) ? settings[key] : null;
        }
    }
}
