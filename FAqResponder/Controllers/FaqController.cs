using FAqResponder.Model;
using FAqResponder.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public ActionResult GetIntegration()
        {
            var configSettings = _telex.GetTelexConfiguration();
            return Ok(configSettings);
        }
    }
}

