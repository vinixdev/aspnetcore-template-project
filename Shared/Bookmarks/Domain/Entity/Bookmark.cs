using Shared.Bookmarks.Domain.Service.Dto;
using Shared.Bookmarks.Domain.ValueObject;
using Shared.Types;

namespace Shared.Bookmarks.Domain.Entity;

public class Bookmark
{
    public BookmarkId Id { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Either<IEnumerable<ApplicationError>, Bookmark> Of(CreateBookmarkDto dto)
    {
        var guard = new Guard();
        
        Guard
            .Check(nameof(Name), dto.Name)
            .MaxLength(3)
            .MaxLength(255)
            .Validate(guard);
        
        
        return guard.HasErrors
            ? guard.GetErrors().ToList()
            : Create(dto);
    }

    private static Bookmark Create(CreateBookmarkDto dto)
    {
        return new Bookmark(dto.Name);
    }
    
    private Bookmark(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }
    
}