using AutoMapper;
using InvoiceApplication.CORE.Entities;
using InvoiceApplication.CORE.Interfaces;
using InvoiceApplication.INFRASTRUCTURE.Data;
using InvoiceApplication.WEB.Models;
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
        private readonly IMapper _mapper;

        public InvoiceController(IAsyncRepository repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AllInvoices()
        {
            List<Factura> allInvoices = await _repository.GetAllInvoices();
            List<FacturaViewModel> invoices = _mapper.Map<List<Factura>, List<FacturaViewModel>>(allInvoices);
            return View("AllInvoices", invoices);
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
