using Bookmarks.Domain.Service.Dto;
using Shared.Types;
using MediatR;

namespace Bookmarks.Application.Commands;

public sealed record CreateBookmarkCommand(CreateBookmarkDto BookmarkDto): IRequest<Either<IEnumerable<ApplicationError>, BookmarkDto>>;