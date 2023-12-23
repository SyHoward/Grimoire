using Grimoire.Services.Deity;
using Microsoft.AspNetCore.Mvc;

namespace Grimoire.WebMvc.Controllers;

public class DeityController : Controller
{
    private readonly IDeityService _deitySerivce;
    private readonly HttpClient _httpClient;
    public DeityController(IDeityService deityService, IHttpClientFactory httpClientFactory)
    {
        _deitySerivce = deityService;
        _httpClient = httpClientFactory.CreateClient("gmapi");
    }
    
    public IActionResult Index()
    {
        return View();
    }
}
