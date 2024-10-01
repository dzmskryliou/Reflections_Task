using System.Configuration;

namespace Reflections_Task
{
    public static class ConfigurationManagerConfigurationProvider
    {
        public static void SaveSetting(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string LoadSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
