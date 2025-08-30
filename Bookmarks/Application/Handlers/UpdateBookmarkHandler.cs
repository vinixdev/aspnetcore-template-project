using Bookmarks.Application.Commands;
using Bookmarks.Domain.Service;
using Bookmarks.Domain.Service.Dto;
using Shared.Types;
using MediatR;

namespace Bookmarks.Application.Handlers;

internal sealed class UpdateBookmarkHandler: IRequestHandler<UpdateBookmarkCommand, Either<IEnumerable<ApplicationError>, BookmarkDto>>
{
    
    private readonly IBookmarkService _bookmarkService;
    
    public UpdateBookmarkHandler(IBookmarkService bookmarkService) => _bookmarkService = bookmarkService;
    
    public Task<Either<IEnumerable<ApplicationError>, BookmarkDto>> Handle(UpdateBookmarkCommand request, CancellationToken cancellationToken)
    {
        return _bookmarkService.UpdateAsync(request.BookmarkId, request.BookmarkDto)
            .MapAsync(BookmarkDto.From);
    }
}
