using System.ComponentModel.DataAnnotations;

namespace domain.Entities;

public class Review : BaseEntity
{
    [MaxLength(8192)] public string Text { get; set; } = null!;

    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
}