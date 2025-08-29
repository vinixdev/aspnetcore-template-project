using Bookmarks.Domain.Entity;
using Bookmarks.Domain.ValueObject;

namespace Bookmarks.Domain.Service;

public interface IBookmarkRepository
{
    Task InsertAsync(Bookmark bookmark);
    Task<IEnumerable<Bookmark>> FindAllAsync();
    Task<Bookmark?> FindByIdAsync(BookmarkId bookmarkId);
    Task ReplaceAsync(Bookmark bookmark);
    Task DeleteAsync(Bookmark bookmark);
}