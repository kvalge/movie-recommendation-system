using DAL.UOW.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.UOW;

public class BaseUow<TDbContext> : IUow
    where TDbContext : DbContext
{
    protected readonly TDbContext UowDbContext;

    public BaseUow(TDbContext uowDbContext)
    {
        UowDbContext = uowDbContext;
    }


    public async Task<int> SaveChangesAsync()
    {
        return await UowDbContext.SaveChangesAsync();
    }
}