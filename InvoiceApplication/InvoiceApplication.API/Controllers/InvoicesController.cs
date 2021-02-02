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



    }
}
