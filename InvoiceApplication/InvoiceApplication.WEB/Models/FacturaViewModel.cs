using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.WEB.Models
{
    public class FacturaViewModel
    {
        public int IdFactura { get; set; }
        [Range(0, int.MaxValue)]
        public int IdLocatie { get; set; }
        [RegularExpression(@"^[a-zA-Z]{1,2} \d{6}$")]
        public string NumarFactura { get; set; }
        public DateTime DataFactura { get; set; }
        [MaxLength(200)]
        public string NumeClient { get; set; }
        public List<DetaliiFacturaViewModel> Detalii { get; set; }
    }
}
