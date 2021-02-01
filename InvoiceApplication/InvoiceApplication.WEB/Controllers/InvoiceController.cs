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
        private readonly ISQLDeliveryService _deliveryService;

        public InvoiceController(IAsyncRepository repository,
                                 ISQLDeliveryService deliveryService)
        {
            _repository = repository;
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<IActionResult> AllInvoices()
        {
            List<Factura> allInvoices = await _deliveryService.GetAllInvoices();
            return View("AllInvoices", allInvoices);
        }

        [HttpGet]
        public IActionResult AddInvoice()
        {
            return View("AddInvoice");
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(Factura invoice)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddInvoice(invoice);
                return RedirectToAction("AllInvoices", "Invoice");
            }
            return View("AddInvoice");
        }
    }
}
