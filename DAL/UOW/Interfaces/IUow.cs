namespace DAL.UOW.Interfaces;

public interface IUow
{
    public Task<int> SaveChangesAsync();
}