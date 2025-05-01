using BLL.DTO;
using Domain.Entities;
using BLL.mappers.Interfaces;

namespace BLL.mappers;

public class RatingValueMapper : IMapper<RatingValueDto, RatingValue>
{
    public RatingValueDto? MapEntityToDto(RatingValue? entity)
    {
        if (entity == null) return null;
        
        return new RatingValueDto
        {
            Id = entity.Id,
            Value = entity.Value,
        };
    }

    public RatingValue? MapDtoToEntity(RatingValueDto? dto)
    {
        if (dto == null) return null;
        
        return new RatingValue
        {
            Id = dto.Id,
            Value = dto.Value,
        };
    }
} 