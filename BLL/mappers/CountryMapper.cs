using BLL.DTO;
using Domain.Entities;
using BLL.mappers.Interfaces;

namespace BLL.mappers;

public class CountryMapper : IMapper<CountryDto, Country>
{
    public CountryDto? MapEntityToDto(Country? entity)
    {
        if (entity == null) return null;
        
        return new CountryDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    public Country? MapDtoToEntity(CountryDto? entity)
    {
        if (entity == null) return null;
        
        return new Country
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}