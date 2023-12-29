using Grimoire.Models.Deity;
using Grimoire.Services.Deity;
using Microsoft.AspNetCore.Mvc;

namespace Grimoire.WebMvc.Controllers;

public class DeityController : Controller
{
    private readonly IDeityService _deityService;
    public DeityController(IDeityService deityService)
    {
        _deityService = deityService;
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DeityCreate deity)
    {
        if(!ModelState.IsValid)
            return View(deity);

        await _deityService.DeityCreateAsync(deity);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IList<DeityRead> deities = await _deityService.GetDeitiesAsnyc();
        return View(deities);
    }

    [HttpGet]
    public async Task<IActionResult> Details (int deityId)
    {
        DeityDetail? model = await _deityService.DeityByIdAsync(deityId);

        if(model is null)
        {
            return NotFound();
        }
        else
        {
            return View(model);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? deityId)
    {
        if (deityId == null)
            return NotFound();
        
        var deity = await _deityService.GetDeityEditAsync(deityId);

        if (deity == null)
            return NotFound();
        
        return View(deity);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int deityId, DeityEdit model)
    {
        if (deityId != model.DeityId)
            return NotFound();

        if (ModelState.IsValid)
        {
            var edit = await _deityService.DeityEditAsync(deityId, model);
            if(edit)
                return RedirectToAction(nameof(Index));
        }

        return View(model);
    }


    [HttpDelete("{deityId:int}")]
    public async Task<IActionResult> Delete(int deityId)
    {
        return await _deityService.DeityDeleteAsync(deityId)
            ? Ok($"Deity {deityId} was deleted successfully.")
            : BadRequest($"Deity {deityId} could not be deleted");
    }

}