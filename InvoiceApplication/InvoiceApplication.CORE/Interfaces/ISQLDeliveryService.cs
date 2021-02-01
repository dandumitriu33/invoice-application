using InvoiceApplication.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.CORE.Interfaces
{
    public interface ISQLDeliveryService
    {
        Task<List<Factura>> GetAllInvoices();
    }
}
