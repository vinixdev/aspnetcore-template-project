using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmarks.Infrastructure.Set;

public class BookmarkSet
{
    [Column("id")]
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string Tag { get; set; }
    public required DateTime CreatedAt { get; set; }
}