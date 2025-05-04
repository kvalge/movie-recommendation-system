using BLL.DTO;
using Domain.Entities;
using BLL.mappers.Interfaces;

namespace BLL.mappers;

public class MovieMapper : IMapper<MovieDto, Movie>
{
    public MovieDto? MapEntityToDto(Movie? entity)
    {
        if (entity == null) return null;
        
        var dto = new MovieDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            ReleaseYear = entity.ReleaseYear,
            Duration = entity.Duration,
            ImageUrl = entity.ImageUrl,
            AvRating = entity.AvRating,
            RatingCount = entity.RatingCount,
            Genres = entity.Genres.ToList(),
            CastAndCrews = entity.CastAndCrews.ToList(),
            Countries = entity.Countries.ToList(),
            Reviews = entity.Reviews.ToList(),
            Ratings = entity.Ratings.ToList()
        };
        
        return dto;
    }

    public Movie? MapDtoToEntity(MovieDto? dto)
    {
        if (dto == null) return null;
        
        var entity = new Movie
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            ReleaseYear = dto.ReleaseYear,
            Duration = dto.Duration,
            ImageUrl = dto.ImageUrl,
            AvRating = dto.AvRating,
            RatingCount = dto.RatingCount,
            Genres = dto.Genres.ToList(),
            CastAndCrews = dto.CastAndCrews.ToList(),
            Countries = dto.Countries.ToList(),
            Reviews = dto.Reviews.ToList(),
            Ratings = dto.Ratings.ToList()
        };

        return entity;
    }
} 