using InvoiceApplication.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApplication.INFRASTRUCTURE.Data
{
    public class EFRepository : IAsyncRepository
    {
        private readonly InvoiceApplicationContext _context;

        public EFRepository(InvoiceApplicationContext context)
        {
            _context = context;
        }
    }
}
