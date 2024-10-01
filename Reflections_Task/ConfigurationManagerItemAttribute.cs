using System;

namespace Reflections_Task
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ConfigurationManagerItemAttribute : Attribute
    {
        public string SettingName { get; }

        public ConfigurationManagerItemAttribute(string settingName)
        {
            SettingName = settingName;
        }
    }
}
