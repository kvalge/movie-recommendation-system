using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Domain.Identifiers;

namespace BLL.DTO;

public class RatingValueDto: IDomainId
{
    public int Id { get; set; }
    
    public int Value { get; set; }
    
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    
    [MaxLength(1024)] public string? Comments { get; set; }
}