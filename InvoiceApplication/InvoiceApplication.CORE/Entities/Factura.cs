using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceApplication.CORE.Entities
{
    public class Factura
    {
        [Column(Order = 1)]
        public int IdFactura { get; set; }
        [Column(Order = 2)]
        public int IdLocatie { get; set; }
        [MaxLength(50)]
        public string NumarFactura { get; set; }
        public DateTime DataFactura { get; set; }
        [MaxLength(200)]
        public string NumeClient { get; set; }
    }
}
