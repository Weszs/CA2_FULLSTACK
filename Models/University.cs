using System.Text.Json.Serialization;

namespace UniversityExplorerPortal.Models;

public class University
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? Website { get; set; }
    public string? Domain { get; set; }
    public string? StateProvince { get; set; }
}

public class UniversityApiResponse
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("web_pages")]
    public List<string>? WebPages { get; set; }

    [JsonPropertyName("domains")]
    public List<string>? Domains { get; set; }

    [JsonPropertyName("state-province")]
    public string? StateProvince { get; set; }
}
