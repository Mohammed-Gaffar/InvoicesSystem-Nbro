using InvoicesSystem.Dtos;
using InvoicesSystem.Models;

namespace InvoicesSystem.Repositories
{
    public interface ICustomerRepository
    {
        Task<BaseResponse> AddCustomer(Customer model);

        Task<List<Customer>> GetCustomers();

        CustomerDto GetCustomerById(Guid id);

        Task<BaseResponse> EditCustomer(CustomerVM model);
        Task<BaseResponse> DeleteCutomer(Guid id);
      

    }
}
