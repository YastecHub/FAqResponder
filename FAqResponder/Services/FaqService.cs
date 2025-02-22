using FAqResponder.Model;
using System.Text.Json;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;

namespace FAqResponder.Services
{
    public class FaqService
    {
        private List<Faq> _faqs;
        private readonly IConfiguration _configuration;
        public FaqService(IConfiguration configuration)
        {
            _configuration = configuration;
            LoadFaqsFromConfiguration();
        }
        private void LoadFaqsFromConfiguration()
        {
            _faqs = _configuration.GetSection("Faqs").Get<List<Faq>>();
            if (_faqs == null) _faqs = new List<Faq>();
        }

        public string GetResponses(string message)
        {
            if (_faqs == null || _faqs.Count == 0) return null;

            foreach (var faq in _faqs)
            {
                if (message.ToLower().Contains(faq.Keyword.ToLower()))
                {
                    return faq.Response;
                }
            }
            return null;
        }

         public void UpdateFaqs(string faqDataJson)
        {
            try
            {
                _faqs = JsonConvert.DeserializeObject<List<Faq>>(faqDataJson);
                if (_faqs == null) _faqs = new List<Faq>(); // Handle deserialization failure
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing FAQ data: {ex.Message}");
                LoadFaqsFromConfiguration(); // Fallback to config if deserialization fails
            }
        }
    }
}
