using Shared.Bookmarks.Domain.Entity;

namespace Shared.Bookmarks.Domain.Service;

public interface IBookmarkRepository
{
    Task InsertAsync(Bookmark bookmark);
}