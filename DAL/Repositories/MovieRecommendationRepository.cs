using BLL.DTO;
using BLL.mappers;
using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace DAL.Repositories;

public class MovieRecommendationRepository : BaseRepository<MovieRecommendationDto, MovieRecommendation>, IMovieRecommendationRepository
{
    public MovieRecommendationRepository (AppDbContext repositoryDbContext) : base(repositoryDbContext, new MovieRecommendationMapper())
    {
    }
}