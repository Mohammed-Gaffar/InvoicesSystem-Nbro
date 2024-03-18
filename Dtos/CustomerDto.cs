using InvoicesSystem.Models;

namespace InvoicesSystem.Dtos
{
    public class CustomerDto
    {
        
        public int Id { get; set; }
        public string CustomerName { get; set; }
         public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
         
        public List<Customer> CustomersList { get; set; }
 

    }
}
