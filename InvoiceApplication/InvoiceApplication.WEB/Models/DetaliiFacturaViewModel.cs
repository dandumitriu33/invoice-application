using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApplication.WEB.Models
{
    public class DetaliiFacturaViewModel
    {
        public int IdDetaliiFactura { get; set; }
        public int IdLocatie { get; set; }
        public int IdFactura { get; set; }
        [MaxLength(200)]
        public string NumeProdus { get; set; }
        public decimal Cantitate { get; set; }
        public decimal PretUnitar { get; set; }
        public decimal Valoare { get; set; }
    }
}
