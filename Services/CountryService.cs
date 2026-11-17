using System.Net.Http.Json;
using UniversityExplorerPortal.Models;

namespace UniversityExplorerPortal.Services;

public class CountryService
{
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Country>> GetCountriesAsync()
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<List<CountryApiResponse>>("countries");
            if (result is null)
            {
                return new List<Country>();
            }

            return result
                .Select(country => new Country
                {
                    Name = country.Name ?? string.Empty,
                    Capital = country.Capital ?? string.Empty,
                    Region = country.Region ?? string.Empty,
                    Population = country.Population,
                    Flag = country.Flag ?? country.Flags.Png ?? string.Empty,
                    FlagUrl = country.Flags.Png ?? country.Flag
                })
                .OrderBy(country => country.Name)
                .ToList();
        }
        catch (Exception)
        {
            return new List<Country>();
        }
    }
}
