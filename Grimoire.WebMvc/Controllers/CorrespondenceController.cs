using Grimoire.Models.Correspondence;
using Grimoire.Services.Correspondence;
using Microsoft.AspNetCore.Mvc;

namespace Grimoire.WebMvc.Controllers;

public class CorrespondenceController : Controller
{
    private readonly ICorrespondenceService _correspondenceSerivce;

    public CorrespondenceController(ICorrespondenceService correspondenceService)
    {
        _correspondenceSerivce = correspondenceService;
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

        await _correspondenceSerivce.CorrespondenceCreateAsync(icon);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IList<CorrespondenceRead> icons = await _correspondenceSerivce.GetCorrespondencesAsnyc();
        return View(icons);
    }

[HttpGet]
    public async Task<IActionResult> Details (int correspondenceId)
    {
        CorrespondenceDetail? model = await _correspondenceSerivce.CorrespondenceByIdAsync(correspondenceId);

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
    public async Task<IActionResult> Edit(int? correspondenceId)
    {
        if (correspondenceId == null)
            return NotFound();
        
        var icon = await _correspondenceSerivce.GetCorrespondenceEditAsync(correspondenceId);

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
            var edit = await _correspondenceSerivce.CorrespondenceEditAsync(correspondenceId, model);
            if(edit)
                return RedirectToAction(nameof(Index));
        }

        return View(model);
    }


    [HttpDelete("{correspondenceId:int}")]
    public async Task<IActionResult> Delete(int correspondenceId)
    {
        return await _correspondenceSerivce.CorrespondenceDeleteAsync(correspondenceId)
            ? Ok($"Correspondence {correspondenceId} was deleted successfully.")
            : BadRequest($"Correspondence {correspondenceId} could not be deleted");
    }


}
