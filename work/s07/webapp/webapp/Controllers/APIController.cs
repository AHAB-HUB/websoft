using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using webapp.Models;
using System.Linq;

namespace webapp.Controllers
{
    public class APIController : Controller
    {
        private readonly ILogger<APIController> _logger;

        public APIController(ILogger<APIController> logger)
        {
            _logger = logger;
        }

        [HttpGet("api/account/{id?}")]
        public IActionResult Account(int id)
        {
            ViewData["id"] = id;
            var json = new JsonReader().Read(id);

            if (json != null)
            {
                return Ok(json);  
            }
            else
            {
                return NotFound(new {Error = "could not load the requested data"});
            }
        }

        [HttpPost("move/{direction?}")]
        [HttpGet("move/{*any}")]
        public IActionResult Move(int direction = 0)
        {
            if (direction < 0)
            {
                Response.Redirect("0");
                direction = 0;
            }
                
            if (direction >= new JsonReader().Read().Count())
                direction = new JsonReader().Read().Count() - 1;

            ViewData["direction"] = direction;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}