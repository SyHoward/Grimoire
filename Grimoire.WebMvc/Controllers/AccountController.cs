using System.Security.Claims;
using Grimoire.Data.Entities;
using Grimoire.Models.Deity;
using Grimoire.Models.User;
using Grimoire.Services.Deity;
using Grimoire.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Grimoire.WebMvc.Controllers;
public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly IDeityService _deityService;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private int _userId;


    public AccountController(IUserService userService, IDeityService deityService, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _userService = userService;
        _deityService = deityService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    private void AssignUserId()
    {
        if (User.Identity.IsAuthenticated)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _userId = int.Parse(userId);
        }
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

    [HttpGet]
    public async Task<IActionResult> Deity()
    {
        IList<UserDeityAdd> deities = await _deityService.GetDeitiesForUserAsnyc();
        return View(deities);
    }

    [HttpPost]
    public async Task<IActionResult> Deity(List<UserDeityAdd> selectedDeities) 
    {
        AssignUserId();
        
        int userId = _userId;

        var deities = await _userService.AddDeityToUser(userId, selectedDeities.Select(d => d.DeityId).ToArray());

        if (deities == null)
            return NotFound();

        return RedirectToAction("Index", "Home");
    }
}
