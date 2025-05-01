using System.ComponentModel.DataAnnotations;
using Domain.Entities.Abstracts;
using Domain.Identity;

namespace Domain.Entities;

public class CastAndCrew : BaseEntityUser<AppUser>
{
    [MaxLength(128)] public string? FirstName { get; set; }

    [MaxLength(128)] public string? LastName { get; set; }

    private string? _stageName;

    [MaxLength(128)]
    public string StageName
    {
        get => _stageName ?? GenerateStageName();
        set => _stageName = value.ToUpper();
    }

    private DateTime? _birthDate;

    public DateTime? BirthDate
    {
        get => _birthDate;
        set => _birthDate = value?.ToUniversalTime();
    }

    [MaxLength(2048)] public string? Description { get; set; }

    [MaxLength(1024)] public string? ImageUrl { get; set; }

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public ICollection<Country> Countries { get; set; } = new List<Country>();

    private string GenerateStageName()
    {
        return !string.IsNullOrEmpty(FirstName)
            ? (string.IsNullOrEmpty(LastName) ? FirstName.ToUpper() : $"{FirstName} {LastName}".ToUpper())
            : (string.IsNullOrEmpty(LastName) ? string.Empty : LastName.ToUpper());
    }
}