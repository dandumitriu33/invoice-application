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

        public async Task<Factura> EditInvoice(Factura invoice)
        {
            Factura invoiceFromDb = await _context.Facturi.Where(f => f.IdFactura == invoice.IdFactura).FirstOrDefaultAsync();
            invoiceFromDb.IdLocatie = invoice.IdLocatie;
            invoiceFromDb.NumarFactura = invoice.NumarFactura;
            invoiceFromDb.DataFactura = invoice.DataFactura;
            invoiceFromDb.NumeClient = invoice.NumeClient;

            _context.Facturi.Attach(invoiceFromDb);
            _context.Entry(invoiceFromDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<DetaliiFactura> AddDetaliiFactura(DetaliiFactura detaliiFactura)
        {
            await _context.DetaliiFacturi.AddAsync(detaliiFactura);
            await _context.SaveChangesAsync();
            return detaliiFactura;
        }

        public async Task<List<DetaliiFactura>> GetDetailsForInvoice(int invoiceId)
        {
            return await _context.DetaliiFacturi.Where(df => df.IdFactura == invoiceId).ToListAsync();
        }
    }
}
