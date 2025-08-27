using Shared.Bookmarks.Domain.Entity;
using Shared.Bookmarks.Domain.ValueObject;
using Shared.Types;

namespace Shared.Bookmarks.Domain.Service;

public interface IBookmarkRepository
{
    Task InsertAsync(Bookmark bookmark);
    Task<IEnumerable<Bookmark>> FindAllAsync();
    Task<Bookmark?> FindByIdAsync(BookmarkId bookmarkId);
    Task ReplaceAsync(Bookmark bookmark);
    Task DeleteAsync(Bookmark bookmark);
}