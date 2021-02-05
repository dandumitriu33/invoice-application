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
        [Range(0, int.MaxValue)]
        public int IdLocatie { get; set; }
        [RegularExpression(@"^[a-zA-Z]{1,2} \d{6}$")]
        public string NumarFactura { get; set; }
        public DateTime DataFactura { get; set; }
        [MaxLength(200)]
        public string NumeClient { get; set; }
    }
}
