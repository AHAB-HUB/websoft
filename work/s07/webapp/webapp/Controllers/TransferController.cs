using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapp.Controllers
{
    public class TransferController : Controller
    {
        private readonly ILogger<TransferController> _logger;

        public TransferController(ILogger<TransferController> logger)
        {
            _logger = logger;
        }

        public IActionResult Transfer(IFormCollection collection)
        {
            if (!string.IsNullOrEmpty(collection["amount"]))
            {
                if (new JsonWriter().TransferMoney(Convert.ToInt32(collection["source"]),
                    Convert.ToInt32(collection["destination"]), Convert.ToInt32(collection["amount"])))
                {
                    return Ok("The transaction has been made successfully.");
                }
                else
                {
                    return NotFound("Could not make the transaction! Please try again.");
                }
            }

            return View();
        }
    }
}