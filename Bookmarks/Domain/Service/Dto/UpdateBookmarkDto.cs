using Bookmarks.Domain.ValueObject;

namespace Bookmarks.Domain.Service.Dto;

public record UpdateBookmarkDto: ModificationBookmarkDto
{
    public required BookmarkId Id { get; set; }
};