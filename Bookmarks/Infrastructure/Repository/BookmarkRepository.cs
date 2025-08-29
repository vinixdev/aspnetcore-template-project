using Bookmarks.Domain.Entity;
using Bookmarks.Domain.Service;
using Bookmarks.Domain.ValueObject;

namespace Bookmarks.Infrastructure.Repository;

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