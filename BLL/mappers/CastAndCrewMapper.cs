using BLL.DTO;
using Domain.Entities;
using BLL.mappers.Interfaces;

namespace BLL.mappers;

public class CastAndCrewMapper : IMapper<CastAndCrewDto, CastAndCrew>
{
    public CastAndCrewDto? MapEntityToDto(CastAndCrew? entity)
    {
        if (entity == null) return null;
        
        return new CastAndCrewDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            StageName = entity.StageName,
            BirthDate = entity.BirthDate,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl,
        };
    }

    public CastAndCrew? MapDtoToEntity(CastAndCrewDto? dto)
    {
        if (dto == null) return null;
        
        return new CastAndCrew
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            StageName = dto.StageName,
            BirthDate = dto.BirthDate,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
        };
    }
} 