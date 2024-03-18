using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silicon_WebApp.Models;

namespace Silicon_WebApp.Controllers;

public class AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : Controller
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly SignInManager<AppUser> _signInManager = signInManager;


    [Route("/register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> Register(RegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            if (!await _userManager.Users.AnyAsync(x => x.Email == model.Email))
            {
                var appUser = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email
                };
                var registerResult = await _userManager.CreateAsync(appUser, model.Password);
                if (registerResult.Succeeded)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(appUser, model.Password, false, false);
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }
                }
            }
        }
        return View(model);
    }

    [Route("/login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Account");
            }

        }
        ViewData["ErrorMessage"] = "Incorrect email or password";
        return View(model);
    }


	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
	}
}
