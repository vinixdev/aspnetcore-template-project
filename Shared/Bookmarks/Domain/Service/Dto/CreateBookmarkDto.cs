namespace Shared.Bookmarks.Domain.Service.Dto;

public record CreateBookmarkDto
{
    public required string Name { get; init; }
    public DateTime CreatedAt { get; init; }
}