using Grimoire.Models.Note;
using Grimoire.Services.Note;
using Microsoft.AspNetCore.Mvc;

namespace Grimoire.WebMvc.Controllers;

public class NoteController : Controller
{
    private readonly INoteService _noteService;
    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NoteCreate note)
    {
        if(!ModelState.IsValid)
            return View(note);

        await _noteService.NoteCreateAsync(note);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IList<NoteRead> notes = await _noteService.GetNotesAsnyc();
        return View(notes);
    }

    [HttpGet]
    public async Task<IActionResult> Details (int noteId)
    {
        NoteDetail? model = await _noteService.NoteByIdAsync(noteId);

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
    public async Task<IActionResult> Edit(int? noteId)
    {
        if (noteId == null)
            return NotFound();
        
        var note = await _noteService.GetNoteEditAsync(noteId);

        if (note == null)
            return NotFound();
        
        return View(note);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int noteId, NoteEdit model)
    {
        if (noteId != model.NoteId)
            return NotFound();

        if (ModelState.IsValid)
        {
            var edit = await _noteService.NoteEditAsync(noteId, model);
            if(edit)
                return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    [HttpDelete("{noteId:int}")]
    public async Task<IActionResult> Delete(int noteId)
    {
        return await _noteService.NoteDeleteAsync(noteId)
            ? Ok($"Note {noteId} was deleted successfully.")
            : BadRequest($"Note {noteId} could not be deleted");
    }
}