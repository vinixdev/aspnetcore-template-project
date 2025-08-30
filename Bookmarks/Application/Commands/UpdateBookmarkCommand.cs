using Bookmarks.Domain.Service.Dto;
using MediatR;
using Shared.Types;

namespace Bookmarks.Application.Commands;

public sealed record UpdateBookmarkCommand(Guid BookmarkId, UpdateBookmarkDto BookmarkDto): IRequest<Either<IEnumerable<ApplicationError>, BookmarkDto>>;