using Grimoire.Models.Note;

namespace Grimoire.Services.Note;

public interface INoteService
{
    Task<List<NoteRead>> GetNotesAsnyc();
    Task<bool> NoteCreateAsync(NoteCreate note);
    Task<NoteDetail?> NoteByIdAsync(int noteId);
    Task<NoteEdit> GetNoteEditAsync(int? noteId);
    Task<bool> NoteEditAsync(int noteId, NoteEdit note);
    Task<bool> NoteDeleteAsync(int noteId);
    void SetOwner(int owner);
}
