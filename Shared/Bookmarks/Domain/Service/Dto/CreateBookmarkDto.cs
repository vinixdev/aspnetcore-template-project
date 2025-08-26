namespace Shared.Bookmarks.Domain.Service.Dto;

public record CreateBookmarkDto
{
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string Tag { get; set; }
}