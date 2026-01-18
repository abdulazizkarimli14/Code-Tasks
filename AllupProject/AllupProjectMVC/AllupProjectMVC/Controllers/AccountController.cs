using AllupProjectMVC.Models;
using AllupProjectMVC.Services.Email;
using AllupProjectMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AllupProjectMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        // GET
        public IActionResult Register() => View();

        // POST
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName= model.FirstName+model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(model);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var link = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, token },
                Request.Scheme);

            await _emailSender.SendEmailAsync(
                user.Email,
                "Confirm your email",
                $"<h3>Welcome!</h3><a href='{link}'>Confirm Email</a>"
            );

            return RedirectToAction("RegisterConfirmation");
        }

        public IActionResult RegisterConfirmation() => View();

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var result = await _userManager.ConfirmEmailAsync(user, token);

            return result.Succeeded
                ? RedirectToAction("Login")
                : BadRequest();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Please confirm your email first.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user, model.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid login attempt");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

