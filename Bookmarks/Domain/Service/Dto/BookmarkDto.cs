using Bookmarks.Domain.Entity;

namespace Bookmarks.Domain.Service.Dto;

public record BookmarkDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string Tag { get; set; }
    public required string CreatedOnUtc { get; set; }

    public static BookmarkDto From(Bookmark bookmark) => new()
    {
        Id = bookmark.Id.ToString(),
        Name = bookmark.Name,
        Url = bookmark.Url,
        Tag = bookmark.Tag,
        CreatedOnUtc = bookmark.CreatedAt.ToString("yyyy MMMM dd HH:mm:ss"),
    };
}