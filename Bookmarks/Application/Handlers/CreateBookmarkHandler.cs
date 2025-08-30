using Bookmarks.Application.Commands;
using Bookmarks.Domain.Service;
using Bookmarks.Domain.Service.Dto;
using MediatR;
using Shared.Types;

namespace Bookmarks.Application.Handlers;

internal sealed class CreateBookmarkHandler: IRequestHandler<CreateBookmarkCommand, Either<IEnumerable<ApplicationError>, BookmarkDto>>
{
    private readonly IBookmarkService _bookmarkService;
    
    public CreateBookmarkHandler(IBookmarkService bookmarkService) => _bookmarkService = bookmarkService;
    
    public Task<Either<IEnumerable<ApplicationError>, BookmarkDto>> Handle(CreateBookmarkCommand request, CancellationToken cancellationToken)
    {
        return _bookmarkService.CreateAsync(request.BookmarkDto)
            .MapAsync(BookmarkDto.From);
    }
}