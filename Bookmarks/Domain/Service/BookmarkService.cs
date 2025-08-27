using Shared.Bookmarks.Domain.Entity;
using Shared.Bookmarks.Domain.Service;
using Shared.Bookmarks.Domain.Service.Dto;
using Shared.Bookmarks.Domain.ValueObject;
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

    public async Task<Either<Nothing, IEnumerable<Bookmark>>> GetAllAsync()
    {
        var bookmarks = await _bookmarkRepository.FindAllAsync();

        return bookmarks.ToList();
    }

    public async Task<Either<ApplicationError, Bookmark>> GetByIdAsync(BookmarkId bookmarkId)
    {
        var bookmark = await _bookmarkRepository.FindByIdAsync(bookmarkId);
        
        return bookmark == null
            ? ApplicationError.Of("BookmarkId", "Bookmark not found")
            : bookmark;
    }

    public Task<Either<IEnumerable<ApplicationError>, Bookmark>> UpdateAsync(BookmarkId bookmarkId, UpdateBookmarkDto dto)
    {
        return GetByIdAsync(bookmarkId)
            .MatchAsync(
                error => new List<ApplicationError> { error },
                _ => CreateEntity(dto, bookmarkId)
            )
            .OnRightAsync(b => _bookmarkRepository.ReplaceAsync(b));
    }

    public Task<Either<ApplicationError, Nothing>> DeleteByIdAsync(BookmarkId bookmarkId)
    {
        return GetByIdAsync(bookmarkId)
            .OnRightAsync(b => _bookmarkRepository.DeleteAsync(b))
            .MapAsync(_ => Nothing.AtAll);
    }


    private Either<IEnumerable<ApplicationError>, Bookmark> CreateEntity(ModificationBookmarkDto dto, BookmarkId? id = null)
    {
        return Bookmark.Of(dto, id);
    } 
}