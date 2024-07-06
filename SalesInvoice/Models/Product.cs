using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    [Required(ErrorMessage = "Item No is required")]
    [Display(Name = "Item No")]
    public int ItemNo { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [Display(Name = "Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    [Display(Name = "Quantity")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be at least 0.01")]
    [Display(Name = "Price")]
    public decimal Price { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Discount cannot be negative")]
    [Display(Name = "Discount")]
    public decimal Discount { get; set; }

    [Display(Name = "Amount")]
    public decimal Amount { get; set; }
}
