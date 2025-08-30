using MediatR;

namespace Bookmarks.Application.Commands;

public sealed record DeleteBookmarkCommand(Guid BookmarkId): IRequest;