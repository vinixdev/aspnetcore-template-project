using Shared.Bookmarks.Domain.Entity;
using Shared.Bookmarks.Domain.Service.Dto;
using Shared.Bookmarks.Domain.ValueObject;
using Shared.Types;

namespace Shared.Bookmarks.Domain.Service;

public interface IBookmarkService
{
    Task<Either<IEnumerable<ApplicationError>, Bookmark>> CreateAsync(CreateBookmarkDto dto);
    Task<Either<Nothing, IEnumerable<Bookmark>>> GetAllAsync();
    Task<Either<ApplicationError, Bookmark>> GetByIdAsync(BookmarkId bookmarkId);
    Task<Either<IEnumerable<ApplicationError>, Bookmark>> UpdateAsync(BookmarkId bookmarkId, UpdateBookmarkDto bookmark);
    Task<Either<ApplicationError, Nothing>> DeleteByIdAsync(BookmarkId bookmarkId);
}