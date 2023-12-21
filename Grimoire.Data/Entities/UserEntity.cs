using Microsoft.AspNetCore.Identity;

namespace Grimoire.Data.Entities;

public class UserEntity : IdentityUser<int>
{
    public string? Name {get; set;}
    public DateTime DateCreated { get; set; }
    // public List Deity.Id  {get; set;}
}