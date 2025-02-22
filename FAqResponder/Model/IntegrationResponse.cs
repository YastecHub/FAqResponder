namespace FAqResponder.Model
{
    public class IntegrationResponse
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Date date { get; set; }
        public Descriptions descriptions { get; set; }
        public string integration_category { get; set; }
        public string integration_type { get; set; }
        public bool is_active { get; set; }
        public List<Output> output { get; set; }
        public List<string> key_features { get; set; }
        public Permissions permissions { get; set; }
        public List<Setting> settings { get; set; }
        public string target_url { get; set; }
    }

    public class Date
    {
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class Descriptions
    {
        public string app_description { get; set; }
        public string app_logo { get; set; }
        public string app_name { get; set; }
        public string app_url { get; set; }
        public string background_color { get; set; }
    }

    public class Output
    {
        public string label { get; set; }
        public bool value { get; set; }
    }

    public class Permissions
    {
        public MonitoringUser monitoring_user { get; set; }
    }

    public class MonitoringUser
    {
        public bool always_online { get; set; }
        public string display_name { get; set; }
    }

    public class Setting
    {
        public string label { get; set; }
        public string type { get; set; }
        public bool required { get; set; }
        public string default_value { get; set; }
        public List<string> options { get; set; }
    }

}
