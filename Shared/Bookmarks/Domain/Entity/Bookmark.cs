using Shared.Bookmarks.Domain.ValueObject;
using Shared.Types;

namespace Shared.Bookmarks.Domain.Entity;

public class Bookmark
{
    public BookmarkId Id { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Either<IEnumerable<ApplicationError>, Bookmark> Of()
    {
       throw new NotImplementedException(); 
    }
    
    private Bookmark()
    {
        Id = Guid.NewGuid();
    }
    
}