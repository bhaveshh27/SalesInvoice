using System.ComponentModel.DataAnnotations;

namespace SalesInvoice.Models
{
    public class SaleInvoice
    {
        [Key]
        public int SalesInvoiceNo { get; set; }

        [Required(ErrorMessage = "Sales Invoice Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Invoice Date")]
        public DateTime SalesInvoiceDate { get; set; }

        [Required(ErrorMessage = "Customer details are required")]
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Sender details are required")]
        public Customer Sender { get; set; }

        [Required(ErrorMessage = "At least one product is required")]
        [MinLength(1, ErrorMessage = "At least one product is required")]
        public List<Product> Products { get; set; } = new List<Product>();

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
    }
}
