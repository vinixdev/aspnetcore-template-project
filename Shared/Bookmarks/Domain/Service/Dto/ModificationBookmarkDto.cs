namespace Shared.Bookmarks.Domain.Service.Dto;

public abstract record ModificationBookmarkDto
{
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string Tag { get; set; }
}