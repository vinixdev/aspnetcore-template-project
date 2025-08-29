using Shared.Bookmarks.Domain.Entity;
using Shared.Bookmarks.Domain.Service;
using Shared.Bookmarks.Domain.ValueObject;

namespace Bookmarks.Infrastructure;

public class BookmarkRepository: IBookmarkRepository
{
    public Task InsertAsync(Bookmark bookmark)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Bookmark>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Bookmark?> FindByIdAsync(BookmarkId bookmarkId)
    {
        throw new NotImplementedException();
    }

    public Task ReplaceAsync(Bookmark bookmark)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Bookmark bookmark)
    {
        throw new NotImplementedException();
    }
}