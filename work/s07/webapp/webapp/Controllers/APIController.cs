using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using webapp.Models;

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

        [HttpGet("move")]
        [HttpPost("move/{Account?}")]
        public IActionResult Move(Account Account)
        {
            ViewData["account"] = new JsonReader().Read(42);
            if (Account == null)
            {
                return View();
            }
            else
            {
                ViewData["account"] = Account;
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}