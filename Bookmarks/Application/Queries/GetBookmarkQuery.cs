using Bookmarks.Domain.Service.Dto;
using MediatR;
using Shared.Types;

namespace Bookmarks.Application.Queries;

public sealed record GetBookmarkQuery(string BookmarkId): IRequest<Either<ApplicationError, BookmarkDto>>;