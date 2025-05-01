using BLL.DTO;
using Domain.Entities;
using BLL.mappers.Interfaces;

namespace BLL.mappers;

public class MovieMapper : IMapper<MovieDto, Movie>
{
    public MovieDto? MapEntityToDto(Movie? entity)
    {
        if (entity == null) return null;
        
        return new MovieDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            ReleaseYear = entity.ReleaseYear,
            Duration = entity.Duration,
            ImageUrl = entity.ImageUrl,
        };
    }

    public Movie? MapDtoToEntity(MovieDto? dto)
    {
        if (dto == null) return null;
        
        return new Movie
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            ReleaseYear = dto.ReleaseYear,
            Duration = dto.Duration,
            ImageUrl = dto.ImageUrl,
        };
    }
} 