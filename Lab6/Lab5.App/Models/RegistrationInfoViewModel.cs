namespace Lab5.App.Models;

using System.ComponentModel.DataAnnotations;

public class RegistrationInfoViewModel
{
    [Required]
    [StringLength(50, ErrorMessage = "Ім'я користувача не може перевищувати 50 символів.")]
    public required string Username { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "ПІБ не може перевищувати 500 символів.")]
    public required string FullName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "Пароль має бути від 8 до 16 символів.")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$%^&*(),.?""{}|<>_])(?=.*[A-Z]).*$",
        ErrorMessage = "Пароль має містити принаймні одну цифру, один спеціальний знак і одну велику літеру.")]
    public required string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Паролі не збігаються.")]
    public required string ConfirmPassword { get; set; }

    [Required]
    [Phone]
    [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Телефон має бути у форматі Україна.")]
    public required string PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }
}
