using InvoiceApplication.CORE.Entities;
using InvoiceApplication.CORE.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.INFRASTRUCTURE.Data
{
    public class EFRepository : IAsyncRepository
    {
        private readonly InvoiceApplicationContext _context;

        public EFRepository(InvoiceApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Factura>> GetAllInvoices()
        {
            return await _context.Facturi.ToListAsync();
        }
    }
}
