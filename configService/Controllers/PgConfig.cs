using Microsoft.AspNetCore.Mvc;
using NLog;
using PGConfigLib;

namespace configService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        [HttpGet("{configName}")]
        public IActionResult Get(string configName)
        {
            var pgcf = new PGConfig();
            string res = pgcf.LoadConfig(configName);
            logger.Info("Loading config for: " + configName);
            return Ok(res);
        }
    }

}
