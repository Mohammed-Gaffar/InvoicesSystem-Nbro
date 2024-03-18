using InvoicesSystem.Dtos;
using InvoicesSystem.Models;

namespace InvoicesSystem.Repositories
{
    public interface ICustomerInvociesRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<List<Product>> GetProducts();
        Task<List<CustomerMasterInvoice>> GetCustomerInvoices();
       
        Task<BaseResponse> AddCustomerInvoce(CustomerInvoiceDto model);



    }
}
