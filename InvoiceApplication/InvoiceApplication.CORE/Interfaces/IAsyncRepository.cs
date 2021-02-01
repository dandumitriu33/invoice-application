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
    }
}
