using AutoMapper;
using InvoiceApplication.CORE.Entities;
using InvoiceApplication.WEB.Models;

namespace InvoiceApplication.WEB.AutomapperProfiles
{
    public class InvoiceApplicationProfiles : Profile
    {
        public InvoiceApplicationProfiles()
        {
            CreateMap<Factura, FacturaViewModel>().ReverseMap();
        }
    }
}
