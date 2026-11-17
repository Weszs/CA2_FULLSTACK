using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityExplorerPortal.Models;

public class StudentApplication
{
    public int Id { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string UniversityName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public DateTime? ApplicationDate { get; set; }
    public string PersonalStatement { get; set; } = string.Empty;
}

public class StudentApplicationApiResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("studentName")]
    public string? StudentName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("university")]
    public string? UniversityName { get; set; }

    [JsonPropertyName("course")]
    public string? CourseName { get; set; }

    [JsonPropertyName("applicationDate")]
    public DateTime? ApplicationDate { get; set; }

    [JsonPropertyName("personalStatement")]
    public string? PersonalStatement { get; set; }
}

public class StudentApplicationRequest
{
    [JsonPropertyName("studentName")]
    public string StudentName { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("university")]
    public string UniversityName { get; set; } = string.Empty;

    [JsonPropertyName("course")]
    public string CourseName { get; set; } = string.Empty;

    [JsonPropertyName("applicationDate")]
    public DateTime? ApplicationDate { get; set; }

    [JsonPropertyName("personalStatement")]
    public string PersonalStatement { get; set; } = string.Empty;
}

public class StudentApplicationFormModel
{
    [Required]
    [StringLength(100)]
    [Display(Name = "Student Name")]
    public string StudentName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    [Display(Name = "Country")]
    public string Country { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    [Display(Name = "University Name")]
    public string UniversityName { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    [Display(Name = "Course Name")]
    public string CourseName { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Application Date")]
    public DateTime? ApplicationDate { get; set; }

    public StudentApplicationRequest ToRequest()
    {
        return new StudentApplicationRequest
        {
            StudentName = StudentName.Trim(),
            Email = Email.Trim(),
            Country = Country.Trim(),
            UniversityName = UniversityName.Trim(),
            CourseName = CourseName.Trim(),
            ApplicationDate = ApplicationDate,
            PersonalStatement = string.Empty
        };
    }
}
