namespace Grimoire.Models.Deity;

public class DeityCreate
{
    public string Name { get; set; } = string.Empty;
    public string? Power { get; set; }
    public int? CorrespondenceId {get; set;}
}