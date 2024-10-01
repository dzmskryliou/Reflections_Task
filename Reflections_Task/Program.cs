using System;

namespace Reflections_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var testConfig = new TestExecutionConfiguration();

            testConfig.LoadSettings();

            Console.WriteLine($"File Environment: {testConfig.FileEnvironment}");
            Console.WriteLine($"File Version: {testConfig.FileVersion}");
            Console.WriteLine($"App Environment: {testConfig.AppEnvironment}");
            Console.WriteLine($"App Version: {testConfig.AppVersion}");

            testConfig.FileEnvironment = "dev";
            testConfig.FileVersion = 4.2f;
            testConfig.AppEnvironment = "test";
            testConfig.AppVersion = 5.1f;

            testConfig.SaveSettings();

            Console.WriteLine("Settings have been saved.");
            Console.ReadKey();
        }
    }

}
