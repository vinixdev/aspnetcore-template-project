using Microsoft.EntityFrameworkCore;

namespace Shared.Repository;

public interface IRepositoryManager<T> where T : class
{
    DbSet<T> Set { get; }
    Task SaveChangesAsync();
}