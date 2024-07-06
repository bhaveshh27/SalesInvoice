using Microsoft.EntityFrameworkCore;
using SalesInvoice.Models;

namespace SalesInvoice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleInvoice> SalesInvoices { get; set; }
    }
}
