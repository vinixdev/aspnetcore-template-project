using Bookmarks.Application.Commands;
using Bookmarks.Domain.Service;
using MediatR;

namespace Bookmarks.Application.Handlers;

internal sealed class DeleteBookmarkHandler: IRequestHandler<DeleteBookmarkCommand>
{
    private IBookmarkService _bookmarkService;
    
    public DeleteBookmarkHandler(IBookmarkService bookmarkService) => _bookmarkService = bookmarkService;
    
    public Task Handle(DeleteBookmarkCommand request, CancellationToken cancellationToken)
    {
        return _bookmarkService.DeleteByIdAsync(request.BookmarkId);
    }
}