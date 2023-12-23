namespace Grimoire.Models.Deity;

public class DeityDelete
{
    public int DeityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    // public List Correspondence.Id { get; set; }
}