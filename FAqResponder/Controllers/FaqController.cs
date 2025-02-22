using FAqResponder.Model;
using FAqResponder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FAqResponder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly FaqService _faqService;

        public FaqController(FaqService faqService)
        {
            _faqService = faqService;
        }

        [HttpPost]
        public IActionResult HandleTelexRequest([FromBody] TelexMessageRequest request)
        {
            try
            {
                string message = request.Message;

                var settingsJson = JsonConvert.SerializeObject(request.Settings);
                var settings = JsonConvert.DeserializeObject<List<TelexSetting>>(settingsJson);

                var faqDataSetting = settings?.FirstOrDefault(s => s.Label == "FAQ Data");
                if (faqDataSetting == null)
                {
                    return BadRequest("Missing required setting: FAQ Data.");
                }

                _faqService.UpdateFaqs(faqDataSetting.Default);

                var response = _faqService.GetResponses(message);

                if (response != null)
                {
                    return Ok(new TelexMessageResponse
                    {
                        Message = response
                    });
                }
                else
                {
                    return Ok(new TelexMessageResponse
                    {
                        Message = message
                    });
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Error: {ex.Message}");
                return Ok(new TelexMessageResponse
                {
                    Message = request.Message
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex}");
                return Ok(new TelexMessageResponse
                {
                    Message = request.Message
                });
            }
        }

        [HttpGet("data")]
        public IActionResult GetIntegrationData()
        {
            var data = _integrationData.Integration.Select(i => i.Data).ToList();
            return Ok(data);
        }

        private static readonly IntegrationResponse _integrationData = new()
        {
            Integration = new List<IntegrationItem>
        {
            new IntegrationItem
            {
                Data = new IntegrationData
                {
                    Date = new DateInfo
                    {
                        CreatedAt = "2024-10-27",
                        UpdatedAt = "2024-10-27"
                    },
                    Descriptions = new Descriptions
                    {
                        AppDescription = "Answers frequently asked questions.",
                        AppLogo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1_aSwcH5s1rO9I8UvT6qZXYTuwyAfUluD2g&s",
                        AppName = "FAQ Bot",
                        AppUrl = "https://faqresponder.onrender.com/api/Faq/respond",
                        BackgroundColor = "#FFFFFF"
                    },
                    IntegrationCategory = "IT Service Management",
                    IntegrationType = "modifier",
                    IsActive = true,
                    Output = new List<string>(),
                    KeyFeatures = new List<string> { "Answers FAQs" },
                    Permissions = new object(),
                    Settings = new List<Setting>
                    {
                        new Setting
                        {
                            Label = "FAQ Data",
                            Type = "text_area",
                            Required = true,
                            Default = "[{\"question\": \"What is your return policy?\", \"answer\": \"Our return policy is 30 days.\"}]"
                        },
                        new Setting
                        {
                            Label = "FAQ Data",
                            Type = "text_area",
                            Required = true,
                            Default = "[{\"question\": \"What is your name?\", \"answer\": \"Ola of Lagos\"}]"
                        },
                        new Setting
                        {
                            Label = "Similarity Threshold",
                            Type = "number",
                            Required = true,
                            Default = "0.8"
                        }
                    },
                    TargetUrl = "https://faqresponder.onrender.com/api/Faq/respond/webhook"
                }
            }
        }
        };
    }
}

