using BLL.mappers.Interfaces;
using DAL.Repositories.Interfaces;
using Domain.Identifiers;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class BaseRepository<TDto, TDomain> : BaseRepository<TDto, TDomain, int>, IRepository<TDto>
    where TDto : class, IDomainId
    where TDomain : class, IDomainId
{
    public BaseRepository(DbContext repositoryDbContext, IMapper<TDto, TDomain> iMapper)
        : base(repositoryDbContext, iMapper)
    {
    }
}

public class BaseRepository<TDto, TDomain, TKey> : IRepository<TDto, TKey>
    where TDto : class, IDomainId<TKey>
    where TDomain : class, IDomainId<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly DbSet<TDomain> _repositoryDbSet;
    private readonly IMapper<TDto, TDomain> _uowMapper;

    public BaseRepository(DbContext repositoryDbContext, IMapper<TDto, TDomain> uowMapper)
    {
        _uowMapper = uowMapper;
        _repositoryDbSet = repositoryDbContext.Set<TDomain>();
    }

    protected virtual IQueryable<TDomain> GetQuery(TKey? userId = default!)
    {
        var query = _repositoryDbSet.AsQueryable();

        if (typeof(IDomainUserId<TKey>).IsAssignableFrom(typeof(TDomain)) &&
            userId != null &&
            !EqualityComparer<TKey>.Default.Equals(userId, default))
        {
            query = query.Where(e => ((IDomainUserId<TKey>)e).UserId.Equals(userId));
        }

        return query;
    }

    public IEnumerable<TDto> All(TKey? userId = default)
    {
        return GetQuery(userId)
            .ToList()
            .Select(e => _uowMapper.MapEntityToDto(e)!);
    }

    public virtual async Task<IEnumerable<TDto>> AllAsync(TKey? userId = default)
    {
        return (await GetQuery(userId)
                .ToListAsync())
            .Select(e => _uowMapper.MapEntityToDto(e)!);
    }

    public TDto? Find(TKey id, TKey? userId = default)
    {
        var query = GetQuery(userId);
        var res = query.FirstOrDefault(e => e.Id.Equals(id));
        return _uowMapper.MapEntityToDto(res);
    }

    public virtual async Task<TDto?> FindAsync(TKey id, TKey? userId = default)
    {
        var query = GetQuery(userId);
        var res = await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
        return _uowMapper.MapEntityToDto(res);
    }

    public virtual void Add(TDto dto, TKey? userId = default)
    {
        var entity = _uowMapper.MapDtoToEntity(dto);
        
        if (typeof(IDomainUserId<TKey>).IsAssignableFrom(typeof(TDomain)) &&
            userId != null &&
            !EqualityComparer<TKey>.Default.Equals(userId, default))
        {
            ((IDomainUserId<TKey>) entity!).UserId = userId;
        }
        
        _repositoryDbSet.Add(entity!);
    }

    public virtual TDto Update(TDto dto)
    {
        return _uowMapper.MapEntityToDto(_repositoryDbSet.Update(_uowMapper.MapDtoToEntity(dto)!).Entity)!;
    }

    public void Remove(TDto dto, TKey? userId = default)
    {
        Remove(dto.Id, userId);
    }

    public void Remove(TKey id, TKey? userId = default)
    {
        var query = GetQuery(userId);
        query = query.Where(e => e.Id.Equals(id));
        var entity = query.FirstOrDefault();
        if (entity != null)
        {
            _repositoryDbSet.Remove(entity);
        }
    }

    public virtual async Task RemoveAsync(TKey id, TKey? userId = default)
    {
        var query = GetQuery(userId);
        query = query.Where(e => e.Id.Equals(id));
        var entity = await query.FirstOrDefaultAsync();
        if (entity != null)
        {
            _repositoryDbSet.Remove(entity);
        }
    }

    public virtual bool Exists(TKey id, TKey? userId = default)
    {
        var query = GetQuery(userId);
        return query.Any(e => e.Id.Equals(id));
    }

    public virtual async Task<bool> ExistsAsync(TKey id, TKey? userId = default)
    {
        var query = GetQuery(userId);
        return await query.AnyAsync(e => e.Id.Equals(id));
    }
}