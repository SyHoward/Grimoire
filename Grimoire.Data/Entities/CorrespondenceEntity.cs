using System.ComponentModel.DataAnnotations;

namespace Grimoire.Data.Entities;

public class CorrespondenceEntity
{   
    [Key]
    public int CorrespondenceId { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } 
}
