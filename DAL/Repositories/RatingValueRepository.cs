using BLL.DTO;
using BLL.mappers;
using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace DAL.Repositories;

public class RatingValueRepository: BaseRepository<RatingValueDto, RatingValue>, IRatingValueRepository
{
    public RatingValueRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new RatingValueMapper())
    {
    }
}
