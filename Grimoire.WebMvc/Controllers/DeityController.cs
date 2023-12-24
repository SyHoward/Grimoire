using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using Azure;
using Grimoire.Models.Deity;
using Grimoire.Services.Deity;
using Microsoft.AspNetCore.Mvc;

namespace Grimoire.WebMvc.Controllers;

public class DeityController : Controller
{
    private readonly IDeityService _deityService;
    private readonly HttpClient _httpClient;
    public DeityController(IHttpClientFactory httpClientFactory, IDeityService deityService)
    {
        _httpClient = httpClientFactory.CreateClient("gmapi");
        _deityService = deityService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<DeityViewModel> deities = await _deityService.GetDeitiesAsync();
        return View(deities);
    }

    public async Task<List<DeityViewModel>> GetDeitiesAsnyc()
    {
        return await _httpClient.GetAsync<
    }
}