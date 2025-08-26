using Shared.Bookmarks.Domain.Entity;
using Shared.Bookmarks.Domain.Service;
using Shared.Bookmarks.Domain.Service.Dto;
using Shared.Types;

namespace Bookmarks.Domain.Service;

public class BookmarkService: IBookmarkService
{
    
    private readonly IBookmarkRepository _bookmarkRepository;

    public BookmarkService(IBookmarkRepository bookmarkRepository)
    {
        _bookmarkRepository = bookmarkRepository;
    }
    
    public Task<Either<IEnumerable<ApplicationError>, Bookmark>> CreateAsync(CreateBookmarkDto dto)
    {
        return CreateEntity(dto)
            .OnRightAsync(b => _bookmarkRepository.InsertAsync(b));
    }


    private Either<IEnumerable<ApplicationError>, Bookmark> CreateEntity(CreateBookmarkDto dto)
    {
        return Bookmark.Of(dto);
    } 
}