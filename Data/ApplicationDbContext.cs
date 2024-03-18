using InvoicesSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicesSystem.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        { }
 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerInvoice> CustomerInvoices { get; set; }
        public DbSet<CustomerInvoicesDetails> GetCustomerInvoicesDetails { get; set; }
         
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Laptop",
                    PrductPrice = 23.5,
                },
                 new Product
                 {
                     Id = 2,
                     ProductName = "Keybord",
                     PrductPrice = 10.4,
                 },
                 new Product
                 {
                     Id = 3,
                     ProductName = "Mouse",
                     PrductPrice = 9.1,
                 },
                 new Product
                 {
                     Id = 4,
                     ProductName = "Screen",
                     PrductPrice = 16.3,
                 }
            );
        }
    }
}
