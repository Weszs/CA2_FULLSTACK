using System.Net.Http.Json;
using UniversityExplorerPortal.Models;

namespace UniversityExplorerPortal.Services;

public class StudentApplicationService
{
    private readonly HttpClient _httpClient;

    public StudentApplicationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<StudentApplication>> GetApplicationsAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<StudentApplicationApiResponse>>("studentapplication");
        if (result is null)
        {
            return new List<StudentApplication>();
        }

        return result
            .Select(app => new StudentApplication
            {
                Id = app.Id,
                StudentName = app.StudentName ?? string.Empty,
                Email = app.Email ?? string.Empty,
                Country = app.Country ?? string.Empty,
                UniversityName = app.UniversityName ?? string.Empty,
                CourseName = app.CourseName ?? string.Empty,
                ApplicationDate = app.ApplicationDate,
                PersonalStatement = app.PersonalStatement ?? string.Empty
            })
            .OrderByDescending(app => app.Id)
            .ToList();
    }

    public async Task<StudentApplication?> GetApplicationByIdAsync(int id)
    {
        var applications = await GetApplicationsAsync();
        return applications.FirstOrDefault(app => app.Id == id);
    }

    public async Task<bool> CreateApplicationAsync(StudentApplicationRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("studentapplication", request);
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> UpdateApplicationAsync(int id, StudentApplicationRequest request)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"studentapplication/{id}", request);
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
