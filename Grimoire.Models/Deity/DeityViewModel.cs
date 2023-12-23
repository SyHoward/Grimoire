using System.Text.Json.Serialization;

namespace Grimoire.Models.Deity;

public class DeityViewModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("romanname")]
    public string? RomanName { get; set; }

    [JsonPropertyName("power")]
    public string? Power { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("father")]
    public string? Father { get; set; }

    [JsonPropertyName("mother")]
    public string? Mother { get; set; }
}
