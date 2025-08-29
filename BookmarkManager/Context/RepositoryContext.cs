using Bookmarks.Infrastructure.Set;
using Microsoft.EntityFrameworkCore;

namespace BookmarkManager.Context;

public class RepositoryContext: DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<BookmarkSet>? Bookmarks { get; set; }
}