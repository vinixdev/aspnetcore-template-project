using Bookmarks.Domain.Entity;
using Bookmarks.Domain.Service;
using Bookmarks.Domain.ValueObject;
using Bookmarks.Infrastructure.Set;
using Microsoft.EntityFrameworkCore;
using Shared.Repository;

namespace Bookmarks.Infrastructure.Repository;

public class BookmarkRepository: IBookmarkRepository
{
    private readonly IRepositoryManager<BookmarkSet> _repositoryManager;

    public BookmarkRepository(IRepositoryManager<BookmarkSet> repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task InsertAsync(Bookmark bookmark)
    {
        var bookmarkSet = BookmarkSet.From(bookmark);
        
        await _repositoryManager.Set.AddAsync(bookmarkSet);
        
        await _repositoryManager.SaveChangesAsync();
    }

    public async Task<IEnumerable<Bookmark>> FindAllAsync()
    {
        var bookmarksRows = await _repositoryManager.Set.AsNoTracking().ToListAsync();
        
        var bookmarks = bookmarksRows.Select(b => b.To());
        
        return bookmarks;
    }

    public async Task<Bookmark?> FindByIdAsync(BookmarkId bookmarkId)
    {
        var bookmarkSet = await _repositoryManager.Set.AsNoTracking().FirstOrDefaultAsync(b => b.Id == bookmarkId.ToString());

        return bookmarkSet?.To();
    }

    public async Task ReplaceAsync(Bookmark bookmark)
    {
        var bookmarkSet = BookmarkSet.From(bookmark);

        _repositoryManager.Set.Update(bookmarkSet);

        await _repositoryManager.SaveChangesAsync();
    }

    public async Task DeleteAsync(Bookmark bookmark)
    {
        await _repositoryManager.Set
            .Where(b => b.Id == bookmark.Id.ToString())
            .ExecuteDeleteAsync();
        
        await _repositoryManager.SaveChangesAsync();
    }
}