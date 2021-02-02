using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApplication.API.Models
{
    public class FacturaDTO
    {
        public int IdFactura { get; set; }
        public int IdLocatie { get; set; }
        [MaxLength(50)]
        public string NumarFactura { get; set; }
        public DateTime DataFactura { get; set; }
        [MaxLength(200)]
        public string NumeClient { get; set; }
    }
}
