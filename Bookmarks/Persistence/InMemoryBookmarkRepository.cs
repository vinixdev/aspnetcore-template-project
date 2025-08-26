using Shared.Bookmarks.Domain.Entity;
using Shared.Bookmarks.Domain.Service;
using Shared.Bookmarks.Domain.ValueObject;

namespace Bookmarks.Persistence;

public class InMemoryBookmarkRepository: IBookmarkRepository
{
    private readonly Dictionary<BookmarkId, Bookmark> _bookmarks = new();
    public Task InsertAsync(Bookmark bookmark)
    {
        _bookmarks.Add(bookmark.Id, bookmark);
        return Task.CompletedTask;
    }
}