using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grimoire.Data.Entities;

public class NoteEntity
{
    [Key]
    public int NoteId { get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public int Owner { get; set; }
    public UserEntity User {get; set;}

    [Required]
    [ForeignKey(nameof(Deity))]
    public int DeityId { get; set; }
    public virtual DeityEntity Deity {get; set;}

    [Required, MinLength(1), MaxLength(100)]
    public string Title { get; set; }

    [Required, MinLength(1), MaxLength(4000)]
    public string Body { get; set; }

    [Required]
    public DateTime Created { get; set; }
    public DateTime Modified  { get; set; }
    
}
