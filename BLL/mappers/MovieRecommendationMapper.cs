using BLL.DTO;
using BLL.mappers.Interfaces;
using Domain.Entities;

namespace BLL.mappers;

public class MovieRecommendationMapper: IMapper<MovieRecommendationDto, MovieRecommendation>
{
    public MovieRecommendationDto? MapEntityToDto(MovieRecommendation? entity)
    {
        if (entity == null) return null;
        
        return new MovieRecommendationDto
        {
            Id = entity.Id,
            MovieId = entity.MovieId,
            Movie = entity.Movie,
            Score = entity.Score,
            Reason = entity.Reason,
            IsViewed = entity.IsViewed
        };
    }

    public MovieRecommendation? MapDtoToEntity(MovieRecommendationDto? dto)
    {
        if (dto == null) return null;
        
        return new MovieRecommendation
        {
            Id = dto.Id,
            MovieId = dto.MovieId,
            Movie = dto.Movie,
            Score = dto.Score,
            Reason = dto.Reason,
            IsViewed = dto.IsViewed
        };
    }
}