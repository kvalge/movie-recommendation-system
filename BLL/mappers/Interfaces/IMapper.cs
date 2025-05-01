namespace BLL.mappers.Interfaces;

public interface IMapper<TDto, TEntity>
    where TDto : class
    where TEntity : class
{
    public TDto? MapEntityToDto(TEntity? entity);
    public TEntity? MapDtoToEntity(TDto? entity);
}