using BLL.DTO;
using BLL.mappers;
using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace DAL.Repositories;

public class RatingRepository: BaseRepository<RatingDto, Rating>, IRatingRepository
{
    public RatingRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new RatingMapper())
    {
    }
}