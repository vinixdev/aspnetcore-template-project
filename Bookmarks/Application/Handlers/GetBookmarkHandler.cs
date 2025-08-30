using Bookmarks.Application.Queries;
using Bookmarks.Domain.Service;
using Bookmarks.Domain.Service.Dto;
using MediatR;
using Shared.Types;

namespace Bookmarks.Application.Handlers;

internal sealed class GetBookmarkHandler: IRequestHandler<GetBookmarkQuery, Either<ApplicationError, BookmarkDto>>
{
    
    private readonly IBookmarkService _bookmarkService;
    
    public GetBookmarkHandler(IBookmarkService bookmarkService) => _bookmarkService = bookmarkService;
    
    public Task<Either<ApplicationError, BookmarkDto>> Handle(GetBookmarkQuery request, CancellationToken cancellationToken)
    {
        return _bookmarkService.GetByIdAsync(request.BookmarkId)
            .MapAsync(BookmarkDto.From);
    }
}