using Grimoire.Models.Correspondence;
using Grimoire.Services.Correspondence;
using Microsoft.AspNetCore.Mvc;

namespace Grimoire.WebMvc.Controllers;

public class CorrespondenceController : Controller
{
    private readonly ICorrespondenceService _correspondenceService;
    public CorrespondenceController(ICorrespondenceService correspondenceService)
    {
        _correspondenceService = correspondenceService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CorrespondenceCreate icon)
    {
        if(!ModelState.IsValid)
            return View(icon);

        await _correspondenceService.CorrespondenceCreateAsync(icon);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IList<CorrespondenceRead> icons = await _correspondenceService.GetCorrespondencesAsnyc();
        return View(icons);
    }

[HttpGet]
    [Route("Correspondence/Details/{correspondenceId}")]
    public async Task<IActionResult> Details (int correspondenceId)
    {
        CorrespondenceDetail? model = await _correspondenceService.CorrespondenceByIdAsync(correspondenceId);

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
    [Route("Correspondence/Edit/{correspondenceId}")]
    public async Task<IActionResult> Edit(int? correspondenceId)
    {
        if (correspondenceId == null)
            return NotFound();
        
        var icon = await _correspondenceService.GetCorrespondenceEditAsync(correspondenceId);

        if (icon == null)
            return NotFound();
        
        return View(icon);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int correspondenceId, CorrespondenceEdit model)
    {
        if (correspondenceId != model.CorrespondenceId)
            return NotFound();

        if (ModelState.IsValid)
        {
            var edit = await _correspondenceService.CorrespondenceEditAsync(correspondenceId, model);
            if(edit)
                return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    [HttpGet]
    [Route("Correspondence/Delete/{correspondenceId}")]
    public async Task<IActionResult> Delete([FromRoute] int correspondenceId)
    {
        
        CorrespondenceDetail? correspondence = await _correspondenceService.CorrespondenceByIdAsync(correspondenceId);
        if (correspondence is null)
            return RedirectToAction(nameof(Index));

        return View(correspondence);
    }

    [HttpPost]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> ConfrimDelete(int correspondenceId)
    {
        await _correspondenceService.CorrespondenceDeleteAsync(correspondenceId);
        return RedirectToAction(nameof(Index));
    }
}