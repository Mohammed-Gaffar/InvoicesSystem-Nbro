using InvoicesSystem.Dtos;
using InvoicesSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InvoicesSystem.Controllers
{
    [AllowAnonymous]
    public class InvoicesController : Controller
    {
        private readonly ICustomerInvociesRepository _customerInvocie;

        public InvoicesController(ICustomerInvociesRepository customerInvocie)
        {
            _customerInvocie = customerInvocie;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CustomerInvoiceDto
            {
                CustomersList = await _customerInvocie.GetCustomers(),
                ProductsList = await _customerInvocie.GetProducts(),
                customerMasterInvoicesList = await _customerInvocie.GetCustomerInvoices(),
            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerInvoice(CustomerInvoiceDto model)
        {

            model.CreatedOn = DateTime.Now;

            var response = await _customerInvocie.AddCustomerInvoce(model);

            var customerInvoice = new CustomerInvoiceDto
            {
                CustomersList = await _customerInvocie.GetCustomers(),
                ProductsList = await _customerInvocie.GetProducts(),
                customerMasterInvoicesList = await _customerInvocie.GetCustomerInvoices(),
            };

            if (response.IsSuccess)
            {

                return View("Index", customerInvoice);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
