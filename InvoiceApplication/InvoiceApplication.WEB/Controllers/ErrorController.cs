using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApplication.WEB.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "404 - Page not found.";
                    _logger.LogWarning($"404 error.");
                    break;
                default:
                    ViewBag.ErrorMessage = statusCode.ToString() + " - That's all we know.";
                    _logger.LogWarning($"{statusCode} error.");
                    break;
            }
            return View("Error");
        }

        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ErrorMessage = exceptionDetails.Error.Message;
            _logger.LogError($"The path {exceptionDetails.Path} threw an exception {exceptionDetails.Error}");
            return View("Error");
        }
    }
}
