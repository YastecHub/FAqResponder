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

        [HttpGet("respond")]
        public IActionResult Respond([FromQuery] string message)
        {
            var response = _faqService.GetResponses(message);
            if (response != null)
            {
                return Ok(new
                {
                    Response = response,
                });
            }
            return NotFound("No matching FAQ found.");
        }
    }
}

