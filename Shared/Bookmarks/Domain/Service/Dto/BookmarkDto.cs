using Shared.Bookmarks.Domain.Entity;

namespace Shared.Bookmarks.Domain.Service.Dto;

public record BookmarkDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string Tag { get; set; }
    public required DateTime CreatedAt { get; set; }

    public static BookmarkDto From(Bookmark bookmark) => new()
    {
        Id = bookmark.Id.ToString(),
        Name = bookmark.Name,
        Url = bookmark.Url,
        Tag = bookmark.Tag,
        CreatedAt = bookmark.CreatedAt,
    };
}