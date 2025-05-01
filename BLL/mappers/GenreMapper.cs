using BLL.DTO;
using Domain.Entities;
using BLL.mappers.Interfaces;

namespace BLL.mappers;

public class GenreMapper : IMapper<GenreDto, Genre>
{
    public GenreDto? MapEntityToDto(Genre? entity)
    {
        if (entity == null) return null;
        
        return new GenreDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    public Genre? MapDtoToEntity(GenreDto? dto)
    {
        if (dto == null) return null;
        
        return new Genre
        {
            Id = dto.Id,
            Name = dto.Name,
        };
    }
} 