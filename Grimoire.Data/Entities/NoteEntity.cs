using System.ComponentModel.DataAnnotations;

namespace Grimoire.Data.Entities;

public class NoteEntity
{
    [Key]
    public int NoteId { get; set; }

    [Required]
    public int Owner { get; set; }
    public UserEntity User {get; set;}

    public int? DeityId { get; set; }
    public virtual DeityEntity? Deity {get; set;}

    [Required, MinLength(1), MaxLength(100)]
    public string Title { get; set; }

    [Required, MinLength(1), MaxLength(4000)]
    public string Body { get; set; }

    [Required]
    public DateTime CreatedUtc { get; set; }
    public DateTime? ModifiedUtc  { get; set; }
    
}