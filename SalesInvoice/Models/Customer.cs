using System.ComponentModel.DataAnnotations;

public class Customer
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Company Name is required")]
    [Display(Name = "Company")]
    public string CompanyName { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [Display(Name = "Address")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Phone Number is required")]
    [Phone(ErrorMessage = "Invalid Phone Number")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Display(Name = "Email")]
    public string Email { get; set; }
}
