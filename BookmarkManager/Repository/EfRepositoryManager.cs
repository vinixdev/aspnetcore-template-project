using BookmarkManager.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Repository;

namespace BookmarkManager.Repository;

public class EfRepositoryManager<T>: IRepositoryManager<T> where T : class
{
    private readonly RepositoryContext _repositoryContext;

    public EfRepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }
    
    public DbSet<T> Set => _repositoryContext.Set<T>();
    
    public Task SaveChangesAsync() => _repositoryContext.SaveChangesAsync();
}