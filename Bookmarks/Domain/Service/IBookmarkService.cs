using Bookmarks.Domain.Entity;
using Bookmarks.Domain.Service.Dto;
using Bookmarks.Domain.ValueObject;
using Shared.Types;

namespace Bookmarks.Domain.Service;

public interface IBookmarkService
{
    Task<Either<IEnumerable<ApplicationError>, Bookmark>> CreateAsync(CreateBookmarkDto dto);
    Task<Either<Nothing, IEnumerable<Bookmark>>> GetAllAsync();
    Task<Either<ApplicationError, Bookmark>> GetByIdAsync(BookmarkId bookmarkId);
    Task<Either<IEnumerable<ApplicationError>, Bookmark>> UpdateAsync(BookmarkId bookmarkId, UpdateBookmarkDto bookmark);
    Task<Either<ApplicationError, Nothing>> DeleteByIdAsync(BookmarkId bookmarkId);
}