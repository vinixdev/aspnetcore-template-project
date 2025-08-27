using Shared.Bookmarks.Domain.Service.Dto;
using Shared.Bookmarks.Domain.ValueObject;
using Shared.Types;

namespace Shared.Bookmarks.Domain.Entity;

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
        return new Bookmark(dto.Name);
    }
    
    private Bookmark(string name, BookmarkId? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }
    
}