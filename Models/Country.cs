using System.Text.Json.Serialization;

namespace UniversityExplorerPortal.Models;

public class Country
{
    public string Name { get; set; } = string.Empty;
    public string Capital { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public int Population { get; set; }
    public string Flag { get; set; } = string.Empty;
    public string? FlagUrl { get; set; }
}

public class CountryApiResponse
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("capital")]
    public string? Capital { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("population")]
    public int Population { get; set; }

    [JsonPropertyName("flag")]
    public string? Flag { get; set; }

    [JsonPropertyName("flags")]
    public CountryFlags Flags { get; set; } = new();
}

public class CountryFlags
{
    [JsonPropertyName("png")]
    public string? Png { get; set; }

    [JsonPropertyName("svg")]
    public string? Svg { get; set; }
}
