using System.ComponentModel.DataAnnotations.Schema;
using Bookmarks.Domain.Entity;

namespace Bookmarks.Infrastructure.Set;

public class BookmarkSet
{
    [Column("id")]
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string Tag { get; set; }
    public required DateTime CreatedAt { get; set; }

    public static BookmarkSet From(Bookmark bookmark)
    {
        return new()
        {
            Id = bookmark.Id.ToString(),
            Name = bookmark.Name,
            Url = bookmark.Url,
            Tag = bookmark.Tag,
            CreatedAt = bookmark.CreatedAt,
        };
    }

    public Bookmark To()
    {
        return Bookmark.From(this);
    }
}