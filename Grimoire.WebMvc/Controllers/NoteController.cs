using Grimoire.Models.Note;
using Grimoire.Services.Note;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Grimoire.Data.Entities;
using System.Security.Claims;

namespace Grimoire.WebMvc.Controllers;

public class NoteController : Controller
{
    private readonly INoteService _noteService;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private int _userId;

    public NoteController(INoteService noteService, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _noteService = noteService;
        _userManager = userManager;
        _signInManager = signInManager;
        // _userId = User.Identity.
        // var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        // _userId = int.TryParse(userIdClaim, out var id)? id : 0;
        _userId = 1;
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

        _noteService.SetOwner(_userId);

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
    [Route("Note/Details/{noteId}")]

    public async Task<IActionResult> Details ([FromRoute] int noteId)
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
    [Route("Note/Edit/{noteId}")]
    public async Task<IActionResult> Edit([FromRoute] int? noteId)
    {
        if (noteId == null)
            return NotFound();
        
        var note = await _noteService.GetNoteEditAsync(noteId);

        if (note == null)
            return NotFound();
        
        return View(note);
    }

    [HttpPost] //!
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

    [HttpDelete] 
    [Route("Note/Delete/{noteId}")]//!
    public async Task<IActionResult> Delete(int noteId)
    {
        return await _noteService.NoteDeleteAsync(noteId)
            ? Ok($"Note {noteId} was deleted successfully.")
            : BadRequest($"Note {noteId} could not be deleted");
    }
}