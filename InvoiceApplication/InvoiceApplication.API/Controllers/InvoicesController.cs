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

        public InvoicesController(IAsyncRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<InvoicesController>/get-all-invoices
        [HttpGet]
        [Route("get-all-invoices")]
        public async Task<IActionResult> GetAllInvoices()
        {
            try
            {
                List<Factura> invoicesFromDb = await _repository.GetAllInvoices();
                var payload = JsonSerializer.Serialize(invoicesFromDb);
                return Ok(payload);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
