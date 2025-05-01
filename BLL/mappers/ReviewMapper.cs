using BLL.DTO;
using Domain.Entities;
using BLL.mappers.Interfaces;

namespace BLL.mappers;

public class ReviewMapper : IMapper<ReviewDto, Review>
{
    public ReviewDto? MapEntityToDto(Review? entity)
    {
        if (entity == null) return null;
        
        return new ReviewDto
        {
            Id = entity.Id,
            Text = entity.Text,
        };
    }

    public Review? MapDtoToEntity(ReviewDto? dto)
    {
        if (dto == null) return null;
        
        return new Review
        {
            Id = dto.Id,
            Text = dto.Text,
        };
    }
} 