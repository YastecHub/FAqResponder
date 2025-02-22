public class TelexConfig
{
    public Data data { get; set; } = new Data();
    public string integration_category { get; set; }
    public string integration_type { get; set; }
    public bool is_active { get; set; }
    public List<string> key_features { get; set; } = new List<string>();
    public List<Setting> settings { get; set; } = new List<Setting>();
    public string target_url { get; set; }
}

public class Data
{
    public Date date { get; set; } = new Date();
    public Descriptions descriptions { get; set; } = new Descriptions();
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

public class Setting
{
    public string label { get; set; }
    public string type { get; set; }
    public bool required { get; set; }
    public string @default { get; set; }
}