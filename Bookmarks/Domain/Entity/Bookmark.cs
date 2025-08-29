using Bookmarks.Domain.Service.Dto;
using Bookmarks.Domain.ValueObject;
using Bookmarks.Infrastructure.Set;
using Shared.Types;

namespace Bookmarks.Domain.Entity;

public class Bookmark
{
    public BookmarkId Id { get; private set; }
    public string Name { get; private set; }
    public string Url { get; private set; }
    public string Tag { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static Either<IEnumerable<ApplicationError>, Bookmark> Of(ModificationBookmarkDto dto, BookmarkId? id = null)
    {
        var guard = new Guard();
        
        Guard
            .Check(nameof(Name), dto.Name)
            .MinLength(3)
            .MaxLength(255)
            .Validate(guard);
        
        Guard
            .Check(nameof(Url), dto.Url)
            .IsValidUrl()
            .Validate(guard);
        
        Guard
            .Check(nameof(Tag), dto.Tag)
            .MinLength(3)
            .MaxLength(255)
            .Validate(guard);
        
        
        return guard.HasErrors
            ? guard.GetErrors().ToList()
            : Create(dto);
    }

    private static Bookmark Create(ModificationBookmarkDto dto)
    {
        return new Bookmark(dto.Name, dto.Tag, dto.Url);
    }
    
    private Bookmark(string name, string tag, string url, BookmarkId? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
        Tag = tag;
        Url = url;
    }

    private Bookmark(string id, string name, string tag, string url, DateTime createdAt): this(name, tag, url)
    {
        Id = BookmarkId.From(id);
        CreatedAt = createdAt;
    }

    public static Bookmark From(BookmarkSet bookmarkSet)
    {
        return new Bookmark(bookmarkSet.Id, bookmarkSet.Name, bookmarkSet.Tag, bookmarkSet.Url, bookmarkSet.CreatedAt);
    }
}