namespace Lab5.App.Models;

using System.ComponentModel.DataAnnotations;

public class LoginInfoViewModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
