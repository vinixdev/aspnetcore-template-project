using Shared.Bookmarks.Domain.ValueObject;

namespace Shared.Bookmarks.Domain.Service.Dto;

public record UpdateBookmarkDto: ModificationBookmarkDto
{
    public required BookmarkId Id { get; set; }
};