using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grimoire.Data.Entities;

public class DeityEntity
{
    [Key]
    public int DeityId { get; set; }
    
    [Required]
    public string Name { get; set; } 
    
    [Required, MaxLength(1000)]
    public string? Description { get; set; }
    
    [ForeignKey(nameof(Correspondence))]
    public int CorrespondenceId { get; set; }
    public virtual CorrespondenceEntity Correspondence {get; set;}

    public List<NoteEntity> Notes { get; set; } = new();
}