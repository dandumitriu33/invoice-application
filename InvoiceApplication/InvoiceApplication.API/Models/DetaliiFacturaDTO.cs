using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApplication.API.Models
{
    public class DetaliiFacturaDTO
    {
        public int IdDetaliiFactura { get; set; }
        [Range(0, int.MaxValue)]
        public int IdLocatie { get; set; }
        public int IdFactura { get; set; }
        [MaxLength(200)]
        public string NumeProdus { get; set; }
        [Range(0.0, double.MaxValue)]
        public decimal Cantitate { get; set; }
        [Range(0.0, double.MaxValue)]
        public decimal PretUnitar { get; set; }
        [Range(0.0, double.MaxValue)]
        public decimal Valoare { get; set; }
    }
}
