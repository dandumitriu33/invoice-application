using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceApplication.CORE.Entities
{
    public class DetaliiFactura
    {
        [Key]
        public int IdDetaliiFactura { get; set; }
        public int IdLocatie { get; set; }
        public int IdFactura { get; set; }
        [MaxLength(200)]
        public string NumeProdus { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cantitate { get; set; }
        [Column(TypeName = "money")]
        public decimal PretUnitar { get; set; }
        [Column(TypeName = "money")]
        public decimal Valoare { get; set; }
    }
}
