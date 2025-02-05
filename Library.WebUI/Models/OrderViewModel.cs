using System.ComponentModel.DataAnnotations;

namespace Library.WebUI.Models;

public class OrderViewModel
{
    [Required(ErrorMessage = "Please enter a name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please enter an address")]
    public string Address { get; set; }
    [Required(ErrorMessage = "Please enter a city")]
    public string City { get; set; }
    [Required(ErrorMessage = "Please enter a country")]
    public string Country { get; set; }
    [Required]
    [MinLength(7)]
    public string Phone { get; set; }
    [Required]
    [MinLength(16), MaxLength(16)] 
    public string CardNumber { get; set; }
    [Range(100,999)]
    public int CvvCode { get; set; }
    [Required]
    public string ExpirationDate { get; set; }
}