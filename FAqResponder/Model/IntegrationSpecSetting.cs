namespace FAqResponder.Model
{
    public class DateInfo
    {
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }

    public class Descriptions
    {
        public string AppDescription { get; set; }
        public string AppLogo { get; set; }
        public string AppName { get; set; }
        public string AppUrl { get; set; }
        public string BackgroundColor { get; set; }
    }

    public class Setting
    {
        public string Label { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
        public string Default { get; set; }
    }

    public class IntegrationData
    {
        public DateInfo Date { get; set; }
        public Descriptions Descriptions { get; set; }
        public string IntegrationCategory { get; set; }
        public string IntegrationType { get; set; }
        public bool IsActive { get; set; }
        public List<string> Output { get; set; }
        public List<string> KeyFeatures { get; set; }
        public object Permissions { get; set; }
        public List<Setting> Settings { get; set; }
        public string TargetUrl { get; set; }
    }

    public class IntegrationItem
    {
        public IntegrationData Data { get; set; }
    }

    public class IntegrationResponse
    {
        public List<IntegrationItem> Integration { get; set; }
    }


}
