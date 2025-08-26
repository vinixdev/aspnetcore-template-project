using Shared.Bookmarks.Domain.Entity;
using Shared.Bookmarks.Domain.Service.Dto;
using Shared.Types;

namespace Shared.Bookmarks.Domain.Service;

public interface IBookmarkService
{
    Task<Either<IEnumerable<ApplicationError>, Bookmark>> CreateAsync(CreateBookmarkDto dto);
}