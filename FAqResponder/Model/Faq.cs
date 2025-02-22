namespace FAqResponder.Model
{
    public class Faq
    {
        public string Keyword { get; set; }
        public string Response { get; set; }
    }

    public class TelexMessageRequest
    {
        public string Message { get; set; }
        public List<TelexSetting> Settings { get; set; }
    }

    public class TelexSetting
    {
        public string Label { get; set; }
        public string Default { get; set; }
    }

    public class TelexMessageResponse
    {
        public string Message { get; set; }
    }
}
