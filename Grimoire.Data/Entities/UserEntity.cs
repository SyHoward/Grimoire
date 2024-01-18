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

    public ICollection<DeityEntity> Deities {get; set;} = new List<DeityEntity>();

    public List<NoteEntity> Notes { get; set; } = new();
}