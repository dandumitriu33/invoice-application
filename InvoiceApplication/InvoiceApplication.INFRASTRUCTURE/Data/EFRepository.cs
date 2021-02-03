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

        public async Task<List<Factura>> GetFirstInvoices()
        {
            return await _context.Facturi.Take(3).ToListAsync();
        }

        public async Task SeedDbData()
        {
            List<Factura> invoices = generateSeedInvoices();
            List<DetaliiFactura> details = generateSeedDetails();

            foreach (var invoice in invoices)
            {
                await _context.Facturi.AddAsync(invoice);
                await _context.SaveChangesAsync();
            }
            foreach (var detail in details)
            {
                await _context.DetaliiFacturi.AddAsync(detail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DetaliiFactura> EditInvoiceDetail(DetaliiFactura invoiceDetails)
        {
            DetaliiFactura invoiceDetailsFromDb = await _context.DetaliiFacturi.Where(df => df.IdDetaliiFactura == invoiceDetails.IdDetaliiFactura).FirstOrDefaultAsync();
            invoiceDetailsFromDb.NumeProdus = invoiceDetails.NumeProdus;
            invoiceDetailsFromDb.Cantitate = invoiceDetails.Cantitate;
            invoiceDetailsFromDb.PretUnitar = invoiceDetails.PretUnitar;
            invoiceDetailsFromDb.Valoare = invoiceDetails.Valoare;

            _context.DetaliiFacturi.Attach(invoiceDetailsFromDb);
            _context.Entry(invoiceDetailsFromDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return invoiceDetails;
        }

        public async Task<DetaliiFactura> GetInvoiceDetailById(int detailId)
        {
            return await _context.DetaliiFacturi.Where(df => df.IdDetaliiFactura == detailId).FirstOrDefaultAsync();
        }




        private List<DetaliiFactura> generateSeedDetails()
        {
            List<DetaliiFactura> details = new List<DetaliiFactura>();
            DetaliiFactura temDetails = new DetaliiFactura()
            {
                IdFactura = 1,
                IdLocatie = 44,
                NumeProdus = "Pix albastru transparent.",
                Cantitate = 20.0M,
                PretUnitar = 2.5M,
                Valoare = 50.0M
            };
            details.Add(temDetails);
            DetaliiFactura temDetails2 = new DetaliiFactura()
            {
                IdFactura = 1,
                IdLocatie = 44,
                NumeProdus = "Creion albastru mic.",
                Cantitate = 20.0M,
                PretUnitar = 2.0M,
                Valoare = 40.0M
            };
            details.Add(temDetails2);
            DetaliiFactura temDetails3 = new DetaliiFactura()
            {
                IdFactura = 1,
                IdLocatie = 44,
                NumeProdus = "Marker negru permanent.",
                Cantitate = 20.0M,
                PretUnitar = 6.3M,
                Valoare = 126.0M
            };
            details.Add(temDetails3);
            DetaliiFactura temDetails4 = new DetaliiFactura()
            {
                IdFactura = 2,
                IdLocatie = 44,
                NumeProdus = "Marker negru permanent.",
                Cantitate = 20.0M,
                PretUnitar = 6.3M,
                Valoare = 126.0M
            };
            details.Add(temDetails4);
            DetaliiFactura temDetails5 = new DetaliiFactura()
            {
                IdFactura = 3,
                IdLocatie = 44,
                NumeProdus = "Marker negru permanent.",
                Cantitate = 20.0M,
                PretUnitar = 6.3M,
                Valoare = 126.0M
            };
            details.Add(temDetails5);
            DetaliiFactura temDetails6 = new DetaliiFactura()
            {
                IdFactura = 3,
                IdLocatie = 44,
                NumeProdus = "Marker negru permanent.",
                Cantitate = 20.0M,
                PretUnitar = 6.3M,
                Valoare = 126.0M
            };
            details.Add(temDetails6);
            return details;
        }

        private List<Factura> generateSeedInvoices()
        {
            List<Factura> invoices = new List<Factura>();
            Factura tempInvoice = new Factura()
            {
                IdLocatie = 44,
                NumarFactura = "F 112233",
                DataFactura = new DateTime(2020, 12, 31),
                NumeClient = "S.C. ABC S.R.L."
            };
            Factura tempInvoice2 = new Factura()
            {
                IdLocatie = 44,
                NumarFactura = "F 224433",
                DataFactura = new DateTime(2021, 01, 21),
                NumeClient = "S.C. XYZ S.R.L."
            };
            invoices.Add(tempInvoice2);
            Factura tempInvoice3 = new Factura()
            {
                IdLocatie = 44,
                NumarFactura = "F 332233",
                DataFactura = new DateTime(2021, 01, 24),
                NumeClient = "S.C. NNN S.R.L."
            };
            invoices.Add(tempInvoice3);
            Factura tempInvoice4 = new Factura()
            {
                IdLocatie = 44,
                NumarFactura = "F 442233",
                DataFactura = new DateTime(2021, 01, 25),
                NumeClient = "S.C. ABC S.R.L."
            };
            invoices.Add(tempInvoice4);
            return invoices;
        }
    }
}
