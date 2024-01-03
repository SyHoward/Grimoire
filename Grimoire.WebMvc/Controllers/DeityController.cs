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
    [Route("Deity/Details/{deityId}")]
    public async Task<IActionResult> Details ([FromRoute] int deityId)
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
    [Route("Deity/Edit/{deityId}")]
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


    [HttpGet]
    [Route("Deity/Delete/{deityId}")]
    public async Task<IActionResult> Delete([FromRoute] int deityId)
    {
        
        DeityDetail? deity = await _deityService.DeityByIdAsync(deityId);
        if (deity is null)
            return RedirectToAction(nameof(Index));

        return View(deity);
    }

    [HttpPost]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> ConfrimDelete(int deityId)
    {
        await _deityService.DeityDeleteAsync(deityId);
        return RedirectToAction(nameof(Index));
    }
}