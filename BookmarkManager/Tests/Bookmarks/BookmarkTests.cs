using Bookmarks.Domain.Service;
using Bookmarks.Domain.Entity;
using Bookmarks.Domain.Service.Dto;
using Xunit;

namespace BookmarkManager.Tests.Bookmarks;

[Collection("TestStartup")]
public class BookmarkTests
{
    private readonly IBookmarkService _bookmarkService;

    public BookmarkTests(DependencyFixture dependencyFixture)
    {
        _bookmarkService = dependencyFixture.GetService<IBookmarkService>();
    }


    private async Task<Bookmark> CreateNewBookmark()
    {
        var dto = new CreateBookmarkDto()
        {
            Name = "test bookmark",
            Url = "https://www.example.com",
            Tag = "something",
        };
        
      var result = await _bookmarkService.CreateAsync(dto);

      return result.Right;
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

    [Fact]
    public async Task Should_Get_All_Bookmarks()
    {
        await CreateNewBookmark();

        var result = await _bookmarkService.GetAllAsync();
        
        Assert.True(result.IsRight);

        var bookmarks = result.Right;
        
        Assert.NotEmpty(bookmarks);
    }

    [Fact]
    public async Task Should_Get_Bookmark_With_Id()
    {
        var bookmark = await CreateNewBookmark();
        
        var result = await _bookmarkService.GetByIdAsync(bookmark.Id);
        
        Assert.True(result.IsRight);
    }

    [Fact]
    public async Task Should_Update_Bookmark_When_Data_Is_Valid()
    {
        var bookmark = await CreateNewBookmark();

        var dto = new UpdateBookmarkDto()
        {
            Name = "updated bookmark",
            Url = "https://www.updated.com",
            Tag = "something new",
        };
        
        var result = await _bookmarkService.UpdateAsync(bookmark.Id, dto);
        
        Assert.True(result.IsRight);
        
        var updatedBookmark = result.Right;
        
        Assert.Equal("updated bookmark", updatedBookmark.Name);
    }

    [Fact]
    public async Task Should_Delete_Bookmark_When_Id_Valid()
    {
        var bookmark = await CreateNewBookmark();

        var result = await _bookmarkService.DeleteByIdAsync(bookmark.Id);
        
        Assert.True(result.IsRight);
    }
}