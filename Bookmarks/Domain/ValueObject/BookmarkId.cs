namespace Bookmarks.Domain.ValueObject;

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
    public override string ToString() => Value.ToString("N");
    public static implicit operator Guid(BookmarkId id) => id.Value;
    public static implicit operator BookmarkId(Guid id) => new(id);

    public static implicit operator BookmarkId(string id)
    {
        var result = Guid.TryParse(id, out var parsedId);
        
        return result ? new BookmarkId(parsedId) : throw new ArgumentException(nameof(id));
    }
        

    public static BookmarkId From(string id)
    {
       var guid = new Guid(id); 
       return new BookmarkId(guid);
    }
}