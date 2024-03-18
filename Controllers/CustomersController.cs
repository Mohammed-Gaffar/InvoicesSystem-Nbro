
using InvoicesSystem.Dtos;
using InvoicesSystem.Models;
using InvoicesSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoicesSystem.Controllers
{ 
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customer;


        public CustomersController(ICustomerRepository customer)
        {
            _customer = customer;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = new CustomerDto
            {
                CustomersList = await _customer.GetCustomers(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer model)
        {

            model.CreatedOn = DateTime.Now;

            await _customer.AddCustomer(model);

            var vacancies = new CustomerDto
            {
                CustomersList = await _customer.GetCustomers(),
            };

            return View("Index", vacancies);

        }

        [HttpGet]
        public IActionResult EditCustomer(Guid Id)
        {

            var customer = new CustomerDto
            {
                CustomerName = _customer.GetCustomerById(Id).CustomerName,

                CustomerPhone = _customer.GetCustomerById(Id).CustomerPhone,

                CustomerAddress = _customer.GetCustomerById(Id).CustomerAddress,

            };

            return View("_EditHRRequisitionForm", customer);
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(CustomerVM model)
        {

            model.CreatedOn = DateTime.Now;

            await _customer.EditCustomer(model);

            var vacancies = new CustomerDto
            {
                CustomersList = await _customer.GetCustomers(),
            };

            return View("Index", vacancies);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {

            await _customer.DeleteCutomer(id);

            var vacancies = new CustomerDto
            {
                CustomersList = await _customer.GetCustomers(),
            };

            return View("Index", vacancies);
        }



    }
}
