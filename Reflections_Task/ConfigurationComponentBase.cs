using System;
using System.Reflection;

namespace Reflections_Task
{
    public abstract class ConfigurationComponentBase
    {
        public void SaveSettings()
        {
            var properties = this.GetType().GetProperties();
            foreach (var property in properties)
            {
                var fileAttribute = property.GetCustomAttribute<FileItemAttribute>();
                if (fileAttribute != null)
                {
                    var value = property.GetValue(this)?.ToString();
                    FileConfigurationProvider.SaveSetting(fileAttribute.SettingName, value);
                }

                var configAttribute = property.GetCustomAttribute<ConfigurationManagerItemAttribute>();
                if (configAttribute != null)
                {
                    var value = property.GetValue(this)?.ToString();
                    ConfigurationManagerConfigurationProvider.SaveSetting(configAttribute.SettingName, value);
                }
            }
        }

        public void LoadSettings()
        {
            var properties = this.GetType().GetProperties();
            foreach (var property in properties)
            {
                var fileAttribute = property.GetCustomAttribute<FileItemAttribute>();
                if (fileAttribute != null)
                {
                    var value = FileConfigurationProvider.LoadSetting(fileAttribute.SettingName);
                    if (value != null)
                    {
                        property.SetValue(this, Convert.ChangeType(value, property.PropertyType));
                    }
                }

                var configAttribute = property.GetCustomAttribute<ConfigurationManagerItemAttribute>();
                if (configAttribute != null)
                {
                    var value = ConfigurationManagerConfigurationProvider.LoadSetting(configAttribute.SettingName);
                    if (value != null)
                    {
                        property.SetValue(this, Convert.ChangeType(value, property.PropertyType));
                    }
                }
            }
        }
    }
}
