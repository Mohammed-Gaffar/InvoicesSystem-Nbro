using AutoMapper;
using InvoicesSystem.Data;
using InvoicesSystem.Dtos;
using InvoicesSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicesSystem.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Customer>> GetCustomers()
        {
            var result = await _context.Customers.Where(c => c.IsDeleted == false).ToListAsync();

            return result;
        }

        public CustomerDto GetCustomerById(Guid id)
        {
            var requisition = _context.Customers.FirstOrDefault(v => v.Id.Equals(id));

            var requisitionDto = _mapper.Map<CustomerDto>(requisition);

            return requisitionDto;
        }

        public async Task<BaseResponse> AddCustomer(Customer model)
        {
            model.Id = Guid.NewGuid();
            await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "تم إضافة الإجازة بنجاح"
            };
        }

        public async Task<BaseResponse> EditCustomer(CustomerVM model)
        {
            var result = _mapper.Map<Customer>(model);
            result.UpdatedOn = DateTime.Now;

            _context.Customers.Update(result);

            await _context.SaveChangesAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "تم التعديل بنجاح"
            };
        }


        public async Task<BaseResponse> DeleteCutomer(Guid id)
        {
            var requisition = _context.Customers.FirstOrDefault(v => v.Id.Equals(id));

            requisition.IsDeleted = true;

            _context.Customers.Update(requisition);

            await _context.SaveChangesAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "تم الحذف بنجاح"
            };
        }

    }
}
