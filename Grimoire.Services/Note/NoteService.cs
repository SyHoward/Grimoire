using Grimoire.Data;
using Grimoire.Data.Entities;
using Grimoire.Models.Note;
using Microsoft.EntityFrameworkCore;

namespace Grimoire.Services.Note;

public class NoteService : INoteService
{
    private readonly AppDbContext _context;
    public NoteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> NoteCreateAsync(NoteCreate note)
    {
        NoteEntity entity = new ()
        {
            NoteId = note.NoteId,
            Owner = note.Owner,
            DeityId = note.DeityId,
            Title = note.Title,
            Body = note.Body,
            Created = note.Created,
            Modified = note.Modified
        };
    _context.Notes.Add(entity);
    return await _context.SaveChangesAsync() == 1;
    }

    public async Task<List<NoteRead>> GetNotesAsnyc()
    {
        List<NoteRead> notes = await _context.Notes
            .Select(n => new NoteRead
            {
                NoteId = n.NoteId,
                Owner = n.Owner,
                DeityId = n.DeityId,
                Title = n.Title,
                Body = n.Body,
                Created = n.Created,
                Modified = n.Modified
            })
            .ToListAsync();
        return notes;
    }

    public async Task<NoteDetail?> NoteByIdAsync(int noteId)
    {
        NoteEntity? note = await _context.Notes
            .FirstOrDefaultAsync(d => d.NoteId == noteId);

        return note is null ? null : new()
        {
            NoteId = note.NoteId,
            Owner = note.Owner,
            DeityId = note.DeityId,
            Title = note.Title,
            Body = note.Body,
            Created = note.Created,
            Modified = note.Modified
        };
    }

    public async Task<NoteEdit> GetNoteEditAsync(int? noteId)
    {
        var note = await _context.Notes.FindAsync(noteId);

        NoteEdit model = new()
        {
            NoteId = note.NoteId,
            Owner = note.Owner,
            DeityId = note.DeityId,
            Title = note.Title,
            Body = note.Body,
            Created = note.Created,
            Modified = note.Modified
        };

        return model;
    }


    public async Task<bool> NoteEditAsync(int noteId, NoteEdit note)
    {
        var entity = await _context.Notes.FindAsync(noteId);

        if(entity is null)
            return false;

        entity.NoteId = note.NoteId;
        entity.Owner = note.Owner;
        entity.DeityId = note.DeityId;
        entity.Title = note.Title;
        entity.Body = note.Body;
        entity.Created = note.Created;
        entity.Modified = note.Modified;

        _context.Notes.Update(entity);
        await _context.SaveChangesAsync();

        return true;
    }


    public async Task<bool> NoteDeleteAsync(int noteId)
    {
        var noteEntity = await _context.Notes.FindAsync(noteId);

        _context.Notes.Remove(noteEntity);
        return await _context.SaveChangesAsync() == 1;
    }
}
