namespace InvoicesSystem.Dtos
{
    public class CustomerMasterInvoice
    {
        public Guid InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
