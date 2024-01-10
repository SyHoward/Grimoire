namespace Grimoire.Models.Note;

public class NoteViewModel
{
    public int NoteId { get; set; }
    public int Owner { get; set; }
    public int? DeityId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime? ModifiedUtc { get; set; }
}
