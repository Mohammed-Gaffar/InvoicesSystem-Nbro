namespace InvoicesSystem.Dtos
{
    public class CustomerVM
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public  DateTime CreatedOn { get; set; }

    }

}
