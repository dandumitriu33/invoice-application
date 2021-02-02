using InvoiceApplication.CORE.Entities;
using InvoiceApplication.CORE.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Factura> AddInvoice(Factura invoice)
        {
            await _context.Facturi.AddAsync(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<Factura> GetInvoiceById(int invoiceId)
        {
            return await _context.Facturi.Where(f => f.IdFactura == invoiceId).FirstOrDefaultAsync();
        }
    }
}
