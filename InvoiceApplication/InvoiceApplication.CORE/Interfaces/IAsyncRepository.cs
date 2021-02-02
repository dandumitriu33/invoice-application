using InvoiceApplication.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.CORE.Interfaces
{
    public interface IAsyncRepository
    {
        Task<List<Factura>> GetAllInvoices();
        Task<Factura> AddInvoice(Factura invoice);
        Task<Factura> GetInvoiceById(int invoiceId);
        Task<Factura> EditInvoice(Factura invoice);
        Task<DetaliiFactura> AddDetaliiFactura(DetaliiFactura detaliiFactura);
        Task<List<DetaliiFactura>> GetDetailsForInvoice(int invoiceId);
        Task<List<Factura>> GetFirstInvoices();
        Task SeedDbData();
    }
}
