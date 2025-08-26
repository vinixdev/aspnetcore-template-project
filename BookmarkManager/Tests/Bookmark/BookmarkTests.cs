using Shared.Bookmarks.Domain.Service;
using Shared.Bookmarks.Domain.Service.Dto;
using Xunit;

namespace BookmarkManager.Tests.Bookmark;

[Collection("TestStartup")]
public class BookmarkTests
{
    private readonly IBookmarkService _bookmarkService;

    public BookmarkTests(DependencyFixture dependencyFixture)
    {
        _bookmarkService = dependencyFixture.GetService<IBookmarkService>();
    }

    [Fact]
    public async Task Should_Create_Bookmark_When_Data_Is_Valid()
    {
        // Arrange
        var dto = new CreateBookmarkDto()
        {
            Name = "test bookmark",
            Url = "https://www.example.com",
            Tag = "something",
        };
        
        // Act
        var result = await _bookmarkService.CreateAsync(dto);
        
        // Assert
        Assert.True(result.IsRight);
    }

    [Fact]
    public async Task Should_Validation_Error_When_Bookmark_Data_Is_Not_Valid()
    {
        var dto = new CreateBookmarkDto()
        {
            Name = "t",
            Url = "invalid url",
            Tag = "ta"
        };
        
        var result = await _bookmarkService.CreateAsync(dto);
        
        Assert.False(result.IsRight);
    }
}