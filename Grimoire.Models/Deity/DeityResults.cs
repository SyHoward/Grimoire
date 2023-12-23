using System.Text.Json.Serialization;

namespace Grimoire.Models.Deity;

public class DeityResults<TResult>
{
    [JsonPropertyName("count")]
    public int Count {get; set;}
    
    [JsonPropertyName("next")]
    public string? Next {get; set;}

    [JsonPropertyName("previous")]
    public string? Previous {get; set;}    

    [JsonPropertyName("results")]
    public IList<TResult> Results {get; set;} = null!;


    public string? NextPageNum => Next?.Split("?page=").LastOrDefault();
    public string? PreviousPageNum => Previous?.Split("?page=").LastOrDefault();
}