namespace Grimoire.Models.Note;

public class NoteByUserId
{
    public int NoteId { get; set; }
    public int Owner { get; set; }
    public int? DeityId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Modified  { get; set; }
}
