using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicesSystem.Models
{
    public class Customer:BaseAuditableEntity
    {
        
        public Guid Id { get; set; }

        [Required]
        public string  CustomerName { get; set; }
        [Required]
        public string   CustomerPhone{ get; set; }
        public string CustomerAddress { get; set; } 

    }
}
