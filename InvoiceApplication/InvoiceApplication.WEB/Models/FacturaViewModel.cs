using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.WEB.Models
{
    public class FacturaViewModel
    {
        public int IdFactura { get; set; }
        public int IdLocatie { get; set; }
        [MaxLength(50)]
        public string NumarFactura { get; set; }
        public DateTime DataFactura { get; set; }
        [MaxLength(200)]
        public string NumeClient { get; set; }
        public List<DetaliiFacturaViewModel> Detalii { get; set; }
    }
}
