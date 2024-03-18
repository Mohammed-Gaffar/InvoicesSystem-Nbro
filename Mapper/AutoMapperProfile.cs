using AutoMapper;
using InvoicesSystem.Dtos;
using InvoicesSystem.Models;
using InvoicesSystem.Repositories;

namespace InvoicesSystem.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           
          
            CreateMap<CustomerInvoiceDto, VacancyCadidate>().ReverseMap();

            // Customers
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CustomerVM, Customer>().ReverseMap();
             
            CreateMap<CustomerInvoiceDto, CustomerInvoice>().ReverseMap();


        }
    }
}
