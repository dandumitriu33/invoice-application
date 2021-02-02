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
        public async Task<IActionResult> EditInvoice(int invoiceId)
        {
            Factura invoiceFromDb = await _repository.GetInvoiceById(invoiceId);
            if (invoiceFromDb != null)
            {
                FacturaViewModel invoice = _mapper.Map<Factura, FacturaViewModel>(invoiceFromDb);
                return View("EditInvoice", invoice);
            }
            FacturaViewModel newInvoice = new FacturaViewModel();
            return View("EditInvoice", newInvoice);
            
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(FacturaViewModel invoice)
        {
            if (ModelState.IsValid)
            {
                Factura invoiceForDb = _mapper.Map<FacturaViewModel, Factura>(invoice);
                await _repository.AddInvoice(invoiceForDb);
                return RedirectToAction("AllInvoices", "Invoice");
            }
            return View("AddInvoice");
        }

    }
}
