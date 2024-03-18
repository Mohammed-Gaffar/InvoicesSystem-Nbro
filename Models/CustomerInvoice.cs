using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace InvoicesSystem.Models
{
    public class CustomerInvoice : BaseAuditableEntity
    {
        [Key]
        public Guid InvoiceID { get; set; }
        public Guid customerID { get; set; }  
        //public Customer customer { get; set; }
        //public virtual List<CustomerInvoice> customerInvoicesList{ get; set; }

    }
}
