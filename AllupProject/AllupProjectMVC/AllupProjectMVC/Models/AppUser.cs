using Microsoft.AspNetCore.Identity;

namespace AllupProjectMVC.Models;

public class AppUser : IdentityUser
{
    public string? FullName { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int Age { get; set; }
}
