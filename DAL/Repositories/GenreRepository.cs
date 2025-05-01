using BLL.DTO;
using BLL.mappers;
using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace DAL.Repositories;

public class GenreRepository: BaseRepository<GenreDto, Genre>, IGenreRepository
{
    public GenreRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new GenreMapper())
    {
    }
}