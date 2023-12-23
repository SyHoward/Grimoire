using Grimoire.Services.Deity;
using Microsoft.AspNetCore.Mvc;

namespace Grimoire.WebMvc.Controllers;

public class DeityController : Controller
{
    private readonly IDeityService _deitySerivce;

    public DeityController(IDeityService deityService)
    {
        _deitySerivce = deityService;
    }

    public IActionResult Index()
    {
        return View();
    }
}
