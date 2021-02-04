using AutoMapper;
using InvoiceApplication.API.Models;
using InvoiceApplication.CORE.Entities;
using InvoiceApplication.CORE.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvoiceApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IAsyncRepository _repository;
        private readonly IMapper _mapper;

        public InvoicesController(IAsyncRepository repository,
                                  IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<InvoicesController>/get-all-invoices
        [HttpGet]
        [Route("get-all-invoices")]
        public async Task<IActionResult> GetAllInvoices()
        {
            try
            {
                List<Factura> invoicesFromDb = await _repository.GetAllInvoices();
                List<FacturaDTO> invoices = _mapper.Map<List<Factura>, List<FacturaDTO>>(invoicesFromDb);
                var payload = JsonSerializer.Serialize(invoices);
                return Ok(payload);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/<InvoicesController>/add-invoice
        [HttpPost]
        [Route("add-invoice")]
        public async Task<IActionResult> AddInvoice(FacturaDTO facturaDTO)
        {
            try
            {
                Factura newInvoice = _mapper.Map<FacturaDTO, Factura>(facturaDTO);
                await _repository.AddInvoice(newInvoice);
                return Ok(newInvoice);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // POST: api/<InvoicesController>/add-invoice-details
        [HttpPost]
        [Route("add-invoice-details")]
        public async Task<IActionResult> AddInvoiceDetails(DetaliiFacturaDTO detaliiFacturaDTO)
        {
            Factura invoiceFromDb = await _repository.GetInvoiceById(detaliiFacturaDTO.IdFactura);
            if (invoiceFromDb == null)
            {
                return BadRequest();
            }
            DetaliiFactura newDetaliiFactura = _mapper.Map<DetaliiFacturaDTO, DetaliiFactura>(detaliiFacturaDTO);
            await _repository.AddDetaliiFactura(newDetaliiFactura);
            return Ok();
        }

        // PUT: api/<InvoicesController>/update-invoice
        [HttpPut]
        [Route("update-invoice")]
        public async Task<IActionResult> UpdateInvoice(FacturaDTO facturaDTO)
        {
            Factura invoiceFromDb = await _repository.GetInvoiceById(facturaDTO.IdFactura);
            if (invoiceFromDb == null)
            {
                return BadRequest();
            }
            // IdLocatie is a composite primary key and cannot be modified 
            // In order to modify the IdLocatie we have to remove the primary key from it
            //invoiceFromDb.IdLocatie = facturaDTO.IdLocatie;
            invoiceFromDb.NumarFactura = facturaDTO.NumarFactura;
            invoiceFromDb.DataFactura = facturaDTO.DataFactura;
            invoiceFromDb.NumeClient = facturaDTO.NumeClient;
            await _repository.EditInvoice(invoiceFromDb);
            return Ok();
        }

        // PUT: api/<InvoicesController>/update-invoice-detail
        [HttpPut]
        [Route("update-invoice-detail")]
        public async Task<IActionResult> UpdateInvoiceDetail(DetaliiFacturaDTO detaliiFacturaDTO)
        {
            DetaliiFactura detailFromDb = await _repository.GetInvoiceDetailById(detaliiFacturaDTO.IdDetaliiFactura);
            if (detailFromDb == null)
            {
                return BadRequest();
            }
            detailFromDb.NumeProdus = detaliiFacturaDTO.NumeProdus;
            detailFromDb.Cantitate = detaliiFacturaDTO.Cantitate;
            detailFromDb.PretUnitar = detaliiFacturaDTO.PretUnitar;
            detailFromDb.Valoare = detaliiFacturaDTO.Valoare;
            await _repository.EditInvoiceDetail(detailFromDb);
            return Ok();
        }

        // DELETE: api/<InvoicesController>/delete-invoice-detail
        [HttpDelete]
        [Route("delete-invoice-detail")]
        public async Task<IActionResult> DeleteInvoiceDetail(DetaliiFacturaDTO detaliiFacturaDTO)
        {
            DetaliiFactura detailFromDb = await _repository.GetInvoiceDetailById(detaliiFacturaDTO.IdDetaliiFactura);
            if (detailFromDb == null)
            {
                return BadRequest();
            }
            await _repository.DeleteInvoiceDetail(detailFromDb);
            return Ok();
        }
    }
}
