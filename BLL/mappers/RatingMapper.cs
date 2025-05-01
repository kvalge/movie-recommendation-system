using BLL.DTO;
using Domain.Entities;
using BLL.mappers.Interfaces;

namespace BLL.mappers;

public class RatingMapper : IMapper<RatingDto, Rating>
{
    public RatingDto? MapEntityToDto(Rating? entity)
    {
        if (entity == null) return null;
        
        return new RatingDto
        {
            Id = entity.Id,
            RatingValue = entity.RatingValue,
        };
    }

    public Rating? MapDtoToEntity(RatingDto? dto)
    {
        if (dto == null) return null;
        
        return new Rating
        {
            Id = dto.Id,
            RatingValue = dto.RatingValue,
        };
    }
} 