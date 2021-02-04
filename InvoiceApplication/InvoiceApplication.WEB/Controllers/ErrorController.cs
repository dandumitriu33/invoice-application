using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApplication.WEB.Controllers
{
    public class ErrorController : Controller
    {
        // GET: /<Controller>/
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "404 - Page not found.";
                    break;
                default:
                    ViewBag.ErrorMessage = statusCode.ToString() + " - That's all we know.";
                    break;
            }
            return View("Error");
        }
    }
}
