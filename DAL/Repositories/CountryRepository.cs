using BLL.DTO;
using BLL.mappers;
using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace DAL.Repositories;

public class CountryRepository : BaseRepository<CountryDto, Country>, ICountryRepository
{
    public CountryRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new CountryMapper())
    {
    }
}