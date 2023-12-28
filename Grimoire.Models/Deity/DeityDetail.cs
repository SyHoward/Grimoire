namespace Grimoire.Models.Deity;

    public class DeityDetail
{
    public int DeityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Power { get; set; }
    public int CorrespondenceId { get; set; }
}
