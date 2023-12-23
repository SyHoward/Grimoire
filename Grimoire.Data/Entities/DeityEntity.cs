using System.ComponentModel.DataAnnotations;

namespace Grimoire.Data.Entities;

public class DeityEntity
{
    [Key]
    public int DeityId { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required, MaxLength(1000)]
    public string? Description { get; set; }
    // public List Correspondence.Id { get; set; }
}