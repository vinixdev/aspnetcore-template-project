using Shared.Bookmarks.Domain.Entity;
using Shared.Bookmarks.Domain.Service;
using Shared.Bookmarks.Domain.ValueObject;
using Shared.Types;

namespace Bookmarks.Persistence;

public class InMemoryBookmarkRepository: IBookmarkRepository
{
    private readonly Dictionary<BookmarkId, Bookmark> _bookmarks = new();
    public Task InsertAsync(Bookmark bookmark)
    {
        _bookmarks.Add(bookmark.Id, bookmark);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Bookmark>> FindAllAsync()
    {
        var bookmarks = _bookmarks.Values.AsEnumerable();

        return Task.FromResult(bookmarks);
    }

    public Task<Bookmark?> FindByIdAsync(BookmarkId bookmarkId)
    {
       var bookmark = _bookmarks.Values.FirstOrDefault(x => x.Id == bookmarkId);
       
       return Task.FromResult(bookmark);
    }

    public Task ReplaceAsync(Bookmark bookmark)
    {
        _bookmarks[bookmark.Id] = bookmark;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Bookmark bookmark)
    {
        _bookmarks.Remove(bookmark.Id);
        return Task.CompletedTask;
    }
}