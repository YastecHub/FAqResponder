using FAqResponder.Model;
using FAqResponder.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FAqResponder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly ITelex _telex;

        public FaqController(ITelex telex)
        {
            _telex = telex;
        }

        [HttpGet("integration.json")]
        public IActionResult GetIntegration()
        {
            var configSettings = _telex.GetTelexConfiguration();
            return Ok(configSettings);
        }

        [HttpPost("webhook")]
        public IActionResult Webhook([FromBody] FaqRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request payload.");
            }

            var responseMessage = _telex.ProcessMessage(request);

            var response = new FaqResponse
            {
                EventName = "faq_responded",
                Message = responseMessage,
                Status = "success",
                Username = "faq-responder-bot"
            };

            return Ok(response);
        }
    }
}

