using System;
namespace Reflections_Task
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FileItemAttribute : Attribute
    {
        public string SettingName { get; }

        public FileItemAttribute(string settingName)
        {
            SettingName = settingName;
        }
    }
}
