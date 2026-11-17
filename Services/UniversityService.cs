using System.Net.Http.Json;
using UniversityExplorerPortal.Models;

namespace UniversityExplorerPortal.Services;

public class UniversityService
{
    private readonly HttpClient _httpClient;

    public UniversityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<University>> GetUniversitiesAsync(string country)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            return new List<University>();
        }

        try
        {
            var result = await _httpClient.GetFromJsonAsync<List<UniversityApiResponse>>($"search?country={Uri.EscapeDataString(country)}");
            if (result is null)
            {
                return new List<University>();
            }

            return result
                .Select(university => new University
                {
                    Name = university.Name ?? string.Empty,
                    Country = university.Country ?? country,
                    Website = university.WebPages is { Count: > 0 } ? university.WebPages[0] : string.Empty,
                    Domain = university.Domains is { Count: > 0 } ? university.Domains[0] : string.Empty,
                    StateProvince = university.StateProvince
                })
                .OrderBy(university => university.Name)
                .ToList();
        }
        catch (Exception)
        {
            return new List<University>();
        }
    }
}
