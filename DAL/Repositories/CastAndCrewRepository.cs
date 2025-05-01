using BLL.DTO;
using BLL.mappers;
using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace DAL.Repositories;

public class CastAndCrewRepository : BaseRepository<CastAndCrewDto, CastAndCrew>, ICastAndCrewRepository
{
    public CastAndCrewRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new CastAndCrewMapper())
    {
    }
}