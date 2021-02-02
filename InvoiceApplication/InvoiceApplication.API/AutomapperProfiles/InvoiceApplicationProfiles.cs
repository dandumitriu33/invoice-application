using AutoMapper;
using InvoiceApplication.API.Models;
using InvoiceApplication.CORE.Entities;

namespace InvoiceApplication.API.AutomapperProfiles
{
    public class InvoiceApplicationProfiles : Profile
    {
        public InvoiceApplicationProfiles()
        {
            CreateMap<Factura, FacturaDTO>().ReverseMap();
            CreateMap<DetaliiFactura, DetaliiFacturaDTO>().ReverseMap();
        }
    }
}
