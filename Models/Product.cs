using System.ComponentModel.DataAnnotations;

namespace InvoicesSystem.Models
{
    public class Product 
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public double PrductPrice { get; set; }

    }
}
