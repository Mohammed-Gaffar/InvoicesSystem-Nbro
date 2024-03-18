using InvoicesSystem.Models;

namespace InvoicesSystem.Dtos
{
    public class CustomerInvoiceDto
    {

        public Guid CustomerId { get; set; }
        public List<Customer> CustomersList { get; set; }
        public Guid ProductId { get; set; }
        public List<Product> ProductsList { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List <CustomerMasterInvoice> customerMasterInvoicesList  { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
