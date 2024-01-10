using Grimoire.Models.Deity;
using Grimoire.Models.User;
using Grimoire.Services.Deity;
using Grimoire.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Grimoire.WebMvc.Controllers;
public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly IDeityService _deityService;


    public AccountController(IUserService userService, IDeityService deityService)
    {
        _userService = userService;
        _deityService = deityService;

    }

    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegister model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var registerResult = await _userService.RegisterUserAsync(model);
        if (registerResult == false)
            return View(model);

        UserLogin loginModel = new()
        {
            UserName = model.UserName,
            Password = model.Password
        };
        await _userService.LoginAsync(loginModel);
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLogin model)
    {
        var loginResult = await _userService.LoginAsync(model);
        if (loginResult == false)
            return View(model);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout ()
    {
        await _userService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Deity()
    {
        IList<DeityRead> deities = await _deityService.GetDeitiesAsnyc();
        return View(deities);
    }

}