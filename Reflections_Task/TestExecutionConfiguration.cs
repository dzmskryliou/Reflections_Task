namespace Reflections_Task
{
    public class TestExecutionConfiguration : ConfigurationComponentBase
    {
        [FileItem("environment")]
        public string FileEnvironment { get; set; }

        [FileItem("version")]
        public float FileVersion { get; set; }

        [ConfigurationManagerItem("environment")]
        public string AppEnvironment { get; set; }

        [ConfigurationManagerItem("version")]
        public float AppVersion { get; set; }
    }

}

