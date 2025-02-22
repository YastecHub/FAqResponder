using FAqResponder.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FAqResponder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        [HttpGet("spec-settings")]
        public IActionResult GetIntegrationSpecSettings()
        {
            var faqs = new List<FaqItem>
            {
                new FaqItem { Question = "What is your return policy?", Answer = "Our return policy is 30 days." },
                new FaqItem { Question = "What is your name?", Answer = "Ask google" }
            };

            var response = new IntegrationResponse
            {
                data = new Data
                {
                    date = new Date
                    {
                        created_at = "2024-10-27",
                        updated_at = "2024-10-27"
                    },
                    descriptions = new Descriptions
                    {
                        app_description = "Answers frequently asked questions.",
                        app_logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1_aSwcH5s1rO9I8UvT6qZXYTuwyAfUluD2g&s",
                        app_name = "FAQ Bot",
                        app_url = "https://faqresponder.onrender.com/api/Faq/spec-settings",
                        background_color = "#FFFFFF"
                    },
                    integration_category = "IT Service Management",
                    integration_type = "modifier",
                    is_active = true,
                    output = new List<Output>
                {
                    new Output { label = "output_channel_1", value = true },
                    new Output { label = "output_channel_2", value = false }
                },
                    key_features = new List<string> { "Answers FAQs" },
                    permissions = new Permissions
                    {
                        monitoring_user = new MonitoringUser
                        {
                            always_online = true,
                            display_name = "Performance Monitor"
                        }
                    },
                    settings = new List<Setting>
                    {
                      new Setting
                      {
                           label = "FAQ Data",
                           type = "text_area",
                           required = true,
                           default_value = JsonSerializer.Serialize(faqs)
                      },
                       new Setting {
                           label = "FAQ Data",
                           type = "text_area",
                           required = true,
                           default_value = "[{\"question\": \"What is your return policy?\", \"answer\": \"Our return policy is 30 days.\"}]"
                       }
                    },
                    target_url = "https://faqresponder.onrender.com/api/Faq/spec-settings/webhook"
                }
            };

            return Ok(response);
        }
    }
}

