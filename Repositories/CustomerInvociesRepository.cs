using AutoMapper;
using InvoicesSystem.Data;
using InvoicesSystem.Dtos;
using InvoicesSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicesSystem.Repositories
{
    public class CustomerInvociesRepository : ICustomerInvociesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
 
        public CustomerInvociesRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse> AddCustomerInvoce(CustomerInvoiceDto model)
        {
            // save to master invoice table
            var customerInvocie = _mapper.Map<CustomerInvoice>(model);

            customerInvocie.InvoiceID = Guid.NewGuid();

            await _context.CustomerInvoices.AddAsync(customerInvocie);

            await _context.SaveChangesAsync();

            return new BaseResponse
            {
                Message = "تم إضافة المرشح بنجاح",
                IsSuccess = true
            };
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            return customers;
        }
         
        public async Task<List<Product>> GetProducts()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }

        public async Task<List<CustomerMasterInvoice>> GetCustomerInvoices()
        {
            var joinedEntities = await _context.CustomerInvoices
                                 .Join(_context.Customers,
                                 cuts => cuts.customerID,
                                 custInvoices => custInvoices.Id,
                                 (center, dept) => new { centerInfo = center, deparments = dept })

                                 .Select(t => new CustomerMasterInvoice
                                 {
                                     InvoiceId = t.centerInfo.InvoiceID,
                                     CreatedOn = t.centerInfo.CreatedOn,
                                     CustomerName = t.deparments.CustomerName,
                                 }).ToListAsync();

            return joinedEntities;

        }
    }
}
