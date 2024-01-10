using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Grimoire.Data.Entities;

public class UserEntity : IdentityUser<int>
{
    [MaxLength(100)]
    public string? FirstName {get; set;}

    [MaxLength(100)]
    public string? LastName {get; set;}

    [Required]
    public DateTime DateCreated { get; set; }

    public int? DeityId { get; set; }
    public virtual DeityEntity? Deity {get; set;}

    public List<NoteEntity> Notes { get; set; } = new();
}