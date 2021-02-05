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
            try
            {
                List<Factura> allInvoices = await _repository.GetAllInvoices();
                List<FacturaViewModel> invoices = _mapper.Map<List<Factura>, List<FacturaViewModel>>(allInvoices);
                return View("AllInvoices", invoices);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message.Split('.')[0]);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AllInvoices(string searchPhrase)
        {
            try
            {
                List<Factura> searchResultsFromDb = await _repository.GetSearchInvoices(searchPhrase);
                if (searchPhrase == null || searchResultsFromDb.Count <= 0)
                {
                    return RedirectToAction("AllInvoices");
                }
                List<FacturaViewModel> searchResults = _mapper.Map<List<Factura>, List<FacturaViewModel>>(searchResultsFromDb);
                ViewBag.SearchMessage = $"Displaying results for '{searchPhrase}'.";
                return View("AllInvoices", searchResults);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message.Split('.')[0]);
            }            
        }

        [HttpGet]
        [Route("editinvoice/{invoiceId}")]
        public async Task<IActionResult> EditInvoice(int invoiceId)
        {
            try
            {
                Factura invoiceFromDb = await _repository.GetInvoiceById(invoiceId);
                if (invoiceFromDb != null)
                {
                    FacturaViewModel invoice = _mapper.Map<Factura, FacturaViewModel>(invoiceFromDb);
                    List<DetaliiFactura> detailsFromDb = await _repository.GetDetailsForInvoice(invoice.IdFactura);
                    List<DetaliiFacturaViewModel> detaliiFactura = _mapper.Map<List<DetaliiFactura>, List<DetaliiFacturaViewModel>>(detailsFromDb);
                    invoice.Detalii = detaliiFactura;
                    return View("EditInvoice", invoice);
                }
                FacturaViewModel newInvoice = new FacturaViewModel();
                newInvoice.IdFactura = 0;
                return View("EditInvoice", newInvoice);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message.Split('.')[0]);
            }
                     
        }

        [HttpGet]
        [Route("deleteinvoice/{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(int invoiceId)
        {
            try
            {
                Factura invoiceFromDb = await _repository.GetInvoiceById(invoiceId);
                if (invoiceFromDb != null)
                {
                    await _repository.DeleteInvoice(invoiceFromDb);
                    return RedirectToAction("AllInvoices");
                }
                return RedirectToAction("AllInvoices");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message.Split('.')[0]);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> EditInvoice(FacturaViewModel invoice)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (invoice.IdFactura == 0)
                    {
                        Factura invoiceForDb = _mapper.Map<FacturaViewModel, Factura>(invoice);
                        await _repository.AddInvoice(invoiceForDb);
                        return RedirectToAction("AllInvoices", "Invoice");
                    }
                    Factura invoiceFromDb = await _repository.GetInvoiceById(invoice.IdFactura);
                    if (invoiceFromDb == null)
                    {
                        return RedirectToAction("EditInvoice");
                    }
                    invoiceFromDb.IdLocatie = invoice.IdLocatie;
                    invoiceFromDb.NumarFactura = invoice.NumarFactura;
                    invoiceFromDb.DataFactura = invoice.DataFactura;
                    invoiceFromDb.NumeClient = invoice.NumeClient;
                    await _repository.EditInvoice(invoiceFromDb);
                    return RedirectToAction("AllInvoices", "Invoice");
                }
                catch (Exception ex)
                {
                    return View("Error", ex.Message.Split('.')[0]);
                }
            }
            return View("AddInvoice");
        }

    }
}
