using System.ComponentModel.DataAnnotations;

namespace FruitesProject.ViewModels.AccountViewModels;

public class LoginVM
{
    [Required(ErrorMessage = "Email tələb olunur")]
    [EmailAddress(ErrorMessage = "Düzgün email daxil edin")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Şifrə tələb olunur")]
    [DataType(DataType.Password)]
    [Display(Name = "Şifrə")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Məni xatırla")]
    public bool RememberMe { get; set; }
}
