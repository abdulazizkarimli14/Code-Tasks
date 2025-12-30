using System.ComponentModel.DataAnnotations;

namespace FruitesProject.ViewModels.AccountViewModels;

public class RegisterVM
{
    [Required(ErrorMessage = "Tam ad tələb olunur")]
    [Display(Name = "Tam Ad")]
    [StringLength(100, ErrorMessage = "{0} maksimum {1} simvol ola bilər")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email tələb olunur")]
    [EmailAddress(ErrorMessage = "Düzgün email daxil edin")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Şifrə tələb olunur")]
    [StringLength(100, ErrorMessage = "{0} ən azı {2} və maksimum {1} simvol olmalıdır.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Şifrə")]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Şifrəni təsdiqlə")]
    [Compare("Password", ErrorMessage = "Şifrələr uyğun gəlmir.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
