using BLL.DTO;
using BLL.mappers;
using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace DAL.Repositories;

public class MovieRepository : BaseRepository<MovieDto, Movie>, IMovieRepository
{
    public MovieRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MovieMapper())
    {
    }
}