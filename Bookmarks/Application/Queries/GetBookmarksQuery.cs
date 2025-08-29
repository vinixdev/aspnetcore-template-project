using MediatR;
using Shared.Bookmarks.Domain.Service.Dto;
using Shared.Types;

namespace Bookmarks.Application.Queries;

public sealed record GetBookmarksQuery(): IRequest<Either<Nothing, IEnumerable<BookmarkDto>>>;