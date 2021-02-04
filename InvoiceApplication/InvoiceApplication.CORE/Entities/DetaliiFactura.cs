using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceApplication.CORE.Entities
{
    public class DetaliiFactura
    {
        public int IdDetaliiFactura { get; set; }
        [Range(0, int.MaxValue)]
        public int IdLocatie { get; set; }
        public int IdFactura { get; set; }
        [MaxLength(200)]
        public string NumeProdus { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.0, double.MaxValue)]
        public decimal Cantitate { get; set; }
        [Column(TypeName = "money")]
        [Range(0.0, double.MaxValue)]
        public decimal PretUnitar { get; set; }
        [Column(TypeName = "money")]
        [Range(0.0, double.MaxValue)]
        public decimal Valoare { get; set; }
    }
}
