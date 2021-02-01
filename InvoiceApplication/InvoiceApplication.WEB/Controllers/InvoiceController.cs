using InvoiceApplication.CORE.Entities;
using InvoiceApplication.CORE.Interfaces;
using InvoiceApplication.INFRASTRUCTURE.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApplication.WEB.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IAsyncRepository _repository;

        public InvoiceController(IAsyncRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> AllInvoices()
        {
            List<Factura> allInvoices = await _repository.GetAllInvoices();
            return View("AllInvoices", allInvoices);
        }
    }
}
