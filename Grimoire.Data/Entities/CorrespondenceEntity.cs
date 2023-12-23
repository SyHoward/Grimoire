using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Grimoire.Data.Entities;

public class CorrespondenceEntity
{   
    [Key]
    public int CorrespondenceId { get; set; }

    [Required, MaxLength(100), NotNull]
    public string Name { get; set; } 
}
