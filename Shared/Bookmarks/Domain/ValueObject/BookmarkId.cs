namespace Shared.Bookmarks.Domain.ValueObject;

public record BookmarkId
{
    public Guid Value { get; }

    public BookmarkId(Guid value)
    {
        if (value.Equals(Guid.Empty))
        {
            throw new ArgumentException(nameof(value));
        }
        
        Value = value;
    }
    
    public static implicit operator Guid(BookmarkId id) => id.Value;
    public static implicit operator BookmarkId(Guid id) => new(id);
}