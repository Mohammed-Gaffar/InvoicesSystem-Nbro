using System.ComponentModel.DataAnnotations;

namespace InvoicesSystem.Models
{
    public class CustomerInvoicesDetails
    {
        [Key]
        public int Id { get; set; }
        public Guid InvoiceId { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public float UntiPrice { get; set; }

    }
}
