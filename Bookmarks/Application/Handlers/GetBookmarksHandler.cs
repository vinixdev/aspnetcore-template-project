using Bookmarks.Application.Queries;
using MediatR;
using Bookmarks.Domain.Service;
using Bookmarks.Domain.Service.Dto;
using Shared.Types;

namespace Bookmarks.Application.Handlers;

internal sealed class GetBookmarksHandler: IRequestHandler<GetBookmarksQuery, Either<Nothing, IEnumerable<BookmarkDto>>>
{
    private readonly IBookmarkService _bookmarkService;
    
    public GetBookmarksHandler(IBookmarkService bookmarkService) => _bookmarkService = bookmarkService;
    
    public Task<Either<Nothing, IEnumerable<BookmarkDto>>> Handle(GetBookmarksQuery request, CancellationToken cancellationToken)
    {
        return _bookmarkService.GetAllAsync()
            .MapAsync(bookmarks => bookmarks.Select(BookmarkDto.From));
    }
}